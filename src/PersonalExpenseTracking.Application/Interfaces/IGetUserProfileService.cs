using PersonalExpenseTracking.Application.DTOs.Response;

namespace PersonalExpenseTracking.Application.Interfaces
{
    public interface IGetUserProfileService
    {
        Task<ResponseUserProfileJson> GetUserProfile();
    }
}
