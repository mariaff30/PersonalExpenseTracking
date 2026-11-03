using PersonalExpenseTracking.Domain.Entities;

namespace PersonalExpenseTracking.Domain.Identity;

public interface ILoggedUser
{
    Task<User> Get();
    Guid GetUserId();
}