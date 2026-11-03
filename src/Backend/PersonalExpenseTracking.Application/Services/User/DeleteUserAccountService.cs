using PersonalExpenseTracking.Application.Interfaces;
using PersonalExpenseTracking.Domain.Identity;
using PersonalExpenseTracking.Domain.Messaging;
using PersonalExpenseTracking.Domain.Repositories.User;

namespace PersonalExpenseTracking.Application.Services.User
{
    public class DeleteUserAccountService : IDeleteUserAccountService
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IScheduleAccountDeletion _scheduleAccountDeletion;

        public DeleteUserAccountService(
            ILoggedUser loggedUser,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IScheduleAccountDeletion scheduleAccountDeletion)
        {
            _loggedUser = loggedUser;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _scheduleAccountDeletion = scheduleAccountDeletion;
        }

        public async Task DeleteUserAccount()
        {
            var userId = _loggedUser.GetUserId();

            await _userWriteOnlyRepository.DeactivateAccount(userId);

            await _scheduleAccountDeletion.Schedule(userId);
        }
    }
}
