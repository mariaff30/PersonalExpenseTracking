using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.Interfaces;
using PersonalExpenseTracking.Application.Services.Password.ResetPassword;
using PersonalExpenseTracking.Domain.Entities;
using PersonalExpenseTracking.Domain.Enums;
using PersonalExpenseTracking.Domain.Repositories.User;
using PersonalExpenseTracking.Domain.Repositories.VerificationCode;
using PersonalExpenseTracking.Domain.Security.PasswordHashing;
using PersonalExpenseTracking.Exception.ExceptionsBase;

namespace PersonalExpenseTracking.Application.Services
{
    public class ResetPasswordService : IResetPasswordService
    {
        private const int ExpirationTimeInMinutes = 10;

        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IVerificationCodeReadOnlyRepository _verificationCodeReadOnlyRepository;
        private readonly IVerificationCodeWriteOnlyRepository _verificationCodeWriteOnlyRepository;
        private readonly IUserUpdateOnlyRepository _userUpdateOnlyRepository;
        private readonly IPasswordHasher _passwordHasher;

        public ResetPasswordService(
            IUserReadOnlyRepository userReadOnlyRepository,
            IVerificationCodeReadOnlyRepository verificationCodeReadOnlyRepository,
            IVerificationCodeWriteOnlyRepository verificationCodeWriteOnlyRepository,
            IUserUpdateOnlyRepository userUpdateOnlyRepository,
            IPasswordHasher passwordHasher)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _verificationCodeReadOnlyRepository = verificationCodeReadOnlyRepository;
            _verificationCodeWriteOnlyRepository = verificationCodeWriteOnlyRepository;
            _userUpdateOnlyRepository = userUpdateOnlyRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task ResetPassword(RequestResetPasswordJson request)
        {
            var user = await _userReadOnlyRepository.GetByEmail(request.Email);
            if (user is null)
                throw new ErrorOnValidationException([ResourceMessagesException.VERIFICATION_CODE_INVALID]);

            var verificationCode = await _verificationCodeReadOnlyRepository.Get(user.Id, request.Code, VerificationCodeType.PasswordRecovery);
            if (verificationCode is null)
                throw new ErrorOnValidationException([ResourceMessagesException.VERIFICATION_CODE_INVALID]);

            ValidateAndThrowOnFailures(request, verificationCode);

            var hashedPassword = _passwordHasher.HashPassword(request.NewPassword);

            await _userUpdateOnlyRepository.UpdatePassword(verificationCode.UserId, hashedPassword);

            await _verificationCodeWriteOnlyRepository.Delete(verificationCode);
        }

        private void ValidateAndThrowOnFailures(RequestResetPasswordJson request, VerificationCode verificationCode)
        {
            var isCodeValid = verificationCode.CreatedAt.AddMinutes(ExpirationTimeInMinutes) >= DateTime.UtcNow;
            if (isCodeValid == false)
                throw new ErrorOnValidationException([ResourceMessagesException.VERIFICATION_CODE_INVALID]);

            var result = new ResetPasswordValidator().Validate(request);

            if (result.IsValid == false)
                throw new ErrorOnValidationException(result.Errors.Select(error => error.ErrorMessage).ToList());
        }
    }
}
