using PersonalExpenseTracking.Application.DTOs.Request;

namespace PersonalExpenseTracking.Application.Interfaces
{
    public interface IRequestPasswordRecoveryCodeService
    {
        Task PasswordRecovery(RequestPasswordRecoveryJson request);
    }
}
