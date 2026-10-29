using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.DTOs.Response;

namespace PersonalExpenseTracking.Application.Interfaces.User
{
    public interface IRegisterUserAccountService
    {
        Task<ResponseRegisteredUserJson> RegisterUserAccount(RequestRegisterUserAccountJson request);
    }
}
