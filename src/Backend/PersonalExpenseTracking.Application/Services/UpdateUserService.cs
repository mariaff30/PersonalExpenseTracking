using FluentValidation.Results;
using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.Interfaces;
using PersonalExpenseTracking.Application.Services.Exceptions;
using PersonalExpenseTracking.Application.Services.Update;
using PersonalExpenseTracking.Domain.Enums;
using PersonalExpenseTracking.Domain.Identity;
using PersonalExpenseTracking.Domain.Repositories;
using PersonalExpenseTracking.Domain.Repositories.User;

namespace PersonalExpenseTracking.Application.Services
{
    internal class UpdateUserService : IUpdateUserService
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserUpdateOnlyRepository _userUpdateOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateUserService(
            ILoggedUser loggedUser,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUserUpdateOnlyRepository userUpdateOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _loggedUser = loggedUser;
            _userReadOnlyRepository = userReadOnlyRepository;
            _userUpdateOnlyRepository = userUpdateOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task UpdateUser(RequestUpdateUserJson request)
        {
            var loggedUser = await _loggedUser.Get();

            await ValidateAndThrowOnFailures(request, loggedUser);

            loggedUser.Name = request.Name;
            loggedUser.Email = request.Email;

            _userUpdateOnlyRepository.UpdateProfile(loggedUser);

            await _unitOfWork.Commit();
        }

        private async Task ValidateAndThrowOnFailures(RequestUpdateUserJson request, Domain.Entities.User loggedUser)
        {
            var validator = new UpdateUserValidator();

            var result = validator.Validate(request);

            if (loggedUser.Email.Equals(request.Email) == false)
            {
                var userExists = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);
                if (userExists)
                    result.Errors.Add(new ValidationFailure("email", ResourceMessagesException.VALIDATION_EMAIL_ALREADY_EXISTS));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
