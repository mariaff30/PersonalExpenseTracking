using PersonalExpenseTracking.Application.DTOs.Request;

namespace PersonalExpenseTracking.Application.Interfaces
{
    public interface IChangePasswordService
    {
        Task UpdatePassword(RequestChangePasswordJson request);
    }
}
