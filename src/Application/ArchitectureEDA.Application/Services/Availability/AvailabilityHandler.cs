using System.Diagnostics;
using MediatR;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Domain.Event;
using ArchitectureEDA.Domain.Interfaces.Persistence.Repository;
using ArchitectureEDA.Domain.Model.Availability;
using ArchitectureEDA.Domain.Model.State.Avaialbility;
using ArchitectureEDA.Domain.Models.Error;

namespace ArchitectureEDA.Application.Services.Availability;

public class AvailabilityHandler : IRequestHandler<AvailabilityRequest>
{
    private const int timeOut = 10000;

    private readonly IKafka _kafka;
    private readonly IRepositoryState _repositoryState;
    private readonly IRepositorySession _repository;
    private readonly Stopwatch _timeExecute;

    public AvailabilityHandler(IKafka kafka, IRepositoryState repositoryState, IRepositorySession repository)
    {
        this._kafka = kafka;
        this._repositoryState = repositoryState;
        this._repository = repository;
        this._timeExecute = new();
    }


    public async Task<Unit> Handle(AvailabilityRequest request, CancellationToken cancellationToken)
    {
        _kafka.Send(AvailabilityEvent.AVAILABILITY_PROVIDER_SERVICE, request);

        try
        {
            bool succeeded = false;
            this._timeExecute.Start();
            while (!succeeded)
            {
                succeeded = await AwaitTimeout();

                if (!succeeded)
                    succeeded = await AwaitFinishProvider(request.CorrelationId);
                await Task.Delay(500);
            }
            this._timeExecute.Stop();

            var resultItems = await _repository.GetByCorrelationId(request.CorrelationId);
            _kafka.Send(AvailabilityEvent.AVAILABILITY_REPLY, resultItems);

        }
        catch (Exception ex)
        {
            _kafka.Send(AvailabilityEvent.AVAILABILITY_ERROR, new ErrorRequest() { Step ="Avaialbility", ExceptionName = ex.Message });
        }

        _kafka.Send(AvailabilityEvent.AVAILABILITY_REPLY, request);
        return Unit.Value;
    }


    private async Task<bool> AwaitFinishProvider(string correlationId)
    {
        var startItems = await this._repositoryState.GetCountStateAsync( AvaialbilityStatusType.Start, correlationId);
        var finishItems = await this._repositoryState.GetCountStateAsync(AvaialbilityStatusType.Finish, correlationId);

        return  startItems > 0 && finishItems > 0 & startItems == finishItems;
    }


    private async Task<bool> AwaitTimeout()
     => this._timeExecute.ElapsedMilliseconds >= timeOut;


}

