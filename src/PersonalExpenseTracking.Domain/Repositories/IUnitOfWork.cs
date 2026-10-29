namespace PersonalExpenseTracking.Domain.Repositories;

public interface IUnitOfWork
{
    Task Commit();
}
