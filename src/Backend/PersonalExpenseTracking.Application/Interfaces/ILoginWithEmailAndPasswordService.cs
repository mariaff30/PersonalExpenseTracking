using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.DTOs.Response;

namespace PersonalExpenseTracking.Application.Interfaces
{
    public interface ILoginWithEmailAndPasswordService
    {
        Task<ResponseRegisteredUserJson> LoginWithEmailAndPassword(RequestLoginJson request);
    }
}
