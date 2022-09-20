using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ArchitectureEDA.Application;
using ArchitectureEDA.Domain;
using ArchitectureEDA.Domain.Common.Kafka;
using ArchitectureEDA.Infrastructure;
using ArchitectureEDA.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication()
.AddDomain()
.AddInfrastructure()
.AddPersitence(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();


var dispacher = app.Services.GetService<IKafka>();
ArgumentNullException.ThrowIfNull(dispacher);
dispacher.Build();


app.Run();

