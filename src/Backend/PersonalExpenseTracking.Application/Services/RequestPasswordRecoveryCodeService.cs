using System.Security.Cryptography;
using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.Interfaces;
using PersonalExpenseTracking.Domain.Entities;
using PersonalExpenseTracking.Domain.Enums;
using PersonalExpenseTracking.Domain.Repositories;
using PersonalExpenseTracking.Domain.Repositories.User;
using PersonalExpenseTracking.Domain.Repositories.VerificationCode;

namespace PersonalExpenseTracking.Application.Services
{
    public class RequestPasswordRecoveryCodeService: IRequestPasswordRecoveryCodeService
    {
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IVerificationCodeWriteOnlyRepository _verificationCodeWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RequestPasswordRecoveryCodeService(
            IUserReadOnlyRepository userReadOnlyRepository,
            IVerificationCodeWriteOnlyRepository verificationCodeWriteOnlyRepository,
            IUnitOfWork unitOfWork)
        {
            _userReadOnlyRepository = userReadOnlyRepository;
            _verificationCodeWriteOnlyRepository = verificationCodeWriteOnlyRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task PasswordRecovery(RequestPasswordRecoveryJson request)
        {
            var user = await _userReadOnlyRepository.GetByEmail(request.Email);
            if (user is null)
                return;

            var code = RandomNumberGenerator.GetInt32(1, 1_000_000);

            var verificationCode = new VerificationCode
            {
                Code = code.ToString("D6"),
                Type = VerificationCodeType.PasswordRecovery,
                UserId = user.Id
            };

            //TODO: Send email with the code

            await _verificationCodeWriteOnlyRepository.Replace(verificationCode);

            await _unitOfWork.Commit();
        }
    }
}
