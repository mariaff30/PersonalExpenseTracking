namespace PersonalExpenseTracking.Domain.Messaging;

public interface IScheduleAccountDeletion
{
    Task Schedule(Guid userId);
}
