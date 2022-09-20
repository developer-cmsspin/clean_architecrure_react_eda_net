using System;
namespace ArchitectureEDA.Domain.Event
{
    public static class AvailabilityEvent
    {
        //AVailability
        public const string AVAILABILITY_SERVICE = "availability_service";
        public const string AVAILABILITY_REPLY = "availability_reply";
        public const string AVAILABILITY_ERROR = "availability_error";

        //provider
        public const string AVAILABILITY_PROVIDER_SERVICE = "availability_provider_service";
        public const string AVAILABILITY_PROVIDER_START = "availability_provider_start";
        public const string AVAILABILITY_PROVIDER_WAITING = "availability_provider_waiting";
        public const string AVAILABILITY_PROVIDER_FINISH = "availability_provider_finish";
        public const string AVAILABILITY_PROVIDER_REPLY = "availability_provider_reply";
    }
}

