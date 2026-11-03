using PersonalExpenseTracking.Application.DTOs.Response;

namespace PersonalExpenseTracking.Application.Interfaces
{
    public interface IGetExpensesUser
    {
        Task<ResponseExpenseUser> GetExpenseUser();
    }
}
