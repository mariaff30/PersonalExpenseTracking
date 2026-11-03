using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.DTOs.Response;
using PersonalExpenseTracking.Application.Interfaces;
using PersonalExpenseTracking.Domain.Entities;
using PersonalExpenseTracking.Domain.Repositories;
using PersonalExpenseTracking.Domain.Repositories.RefreshToken;
using PersonalExpenseTracking.Domain.Repositories.User;
using PersonalExpenseTracking.Domain.Security.PasswordHashing;
using PersonalExpenseTracking.Domain.Security.Tokens;
using PersonalExpenseTracking.Exception.ExceptionsBase;

namespace PersonalExpenseTracking.Application.Services
{
    public class LoginWithEmailAndPasswordService: ILoginWithEmailAndPasswordService
    {

        private readonly IPasswordHasher _passwordHasher;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IRefreshTokenWriteOnlyRepository _refreshTokenWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;

        public LoginWithEmailAndPasswordService(
            IPasswordHasher passwordHasher,
            IUserReadOnlyRepository userReadOnlyRepository,
            IRefreshTokenWriteOnlyRepository refreshTokenWriteOnlyRepository,
            IUnitOfWork unitOfWork,
            IAccessTokenGenerator accessTokenGenerator,
            IRefreshTokenGenerator refreshTokenGenerator)
        {
            _passwordHasher = passwordHasher;
            _userReadOnlyRepository = userReadOnlyRepository;
            _refreshTokenWriteOnlyRepository = refreshTokenWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
        }

        public async Task<ResponseRegisteredUserJson> LoginWithEmailAndPassword(RequestLoginJson request)
        {
            var user = await _userReadOnlyRepository.GetByEmail(request.Email);
            if (user is null)
                throw new InvalidLoginException();

            var isPasswordValid = _passwordHasher.VerifyPassword(request.Password, user.Password);
            if (isPasswordValid == false)
                throw new InvalidLoginException();

            var refreshToken = await GenerateAndSaveRefreshToken(user.Id);

            await _unitOfWork.Commit();

            return new ResponseRegisteredUserJson
            {
                Name = user.Name,
                Tokens = new ResponseTokensJson
                {
                    AccessToken = _accessTokenGenerator.Generate(user),
                    RefreshToken = refreshToken
                }
            };
        }

        private async Task<string> GenerateAndSaveRefreshToken(Guid userId)
        {
            var refreshToken = new RefreshToken
            {
                Value = _refreshTokenGenerator.Generate(),
                UserId = userId
            };

            await _refreshTokenWriteOnlyRepository.Replace(refreshToken);

            return refreshToken.Value;
        }
    }
}
