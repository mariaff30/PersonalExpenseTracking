using PersonalExpenseTracking.Application.DTOs.Request;

namespace PersonalExpenseTracking.Application.Interfaces
{
    public interface IUpdateUserService
    {
        Task UpdateUser(RequestUpdateUserJson request);
    }
}
