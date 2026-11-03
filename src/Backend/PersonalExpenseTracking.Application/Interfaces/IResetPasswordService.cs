using PersonalExpenseTracking.Application.DTOs.Request;

namespace PersonalExpenseTracking.Application.Interfaces
{
    public interface IResetPasswordService
    {
        Task ResetPassword(RequestResetPasswordJson request);
    }
}
