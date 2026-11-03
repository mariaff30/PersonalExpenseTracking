using PersonalExpenseTracking.Application.DTOs.Response;
using PersonalExpenseTracking.Application.Interfaces;
using PersonalExpenseTracking.Domain.Identity;

namespace PersonalExpenseTracking.Application.Services
{
    public class GetUserProfileService: IGetUserProfileService
    {
        private readonly ILoggedUser _loggedUser;

        public GetUserProfileService(ILoggedUser loggedUser)
        {
            _loggedUser = loggedUser;
        }

        public async Task<ResponseUserProfileJson> GetUserProfile()
        {
            var loggedUser = await _loggedUser.Get();

            return new ResponseUserProfileJson
            {
                Name = loggedUser.Name,
                Email = loggedUser.Email
            };
        }
    }
}
