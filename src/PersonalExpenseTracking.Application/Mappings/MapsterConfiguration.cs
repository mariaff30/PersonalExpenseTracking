using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Domain.Entities;
using Mapster;

namespace PersonalExpenseTracking.Application.Mappings
{
    internal static class MapsterConfiguration
    {
        internal static void Configure()
        {
            TypeAdapterConfig<RequestRegisterUserAccountJson, User>
                .NewConfig()
                .Ignore(destination => destination.Password);
        }
    }
}
