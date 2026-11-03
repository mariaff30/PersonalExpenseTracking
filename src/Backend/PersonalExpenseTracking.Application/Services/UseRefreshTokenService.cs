using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.DTOs.Response;
using PersonalExpenseTracking.Application.Interfaces;
using PersonalExpenseTracking.Domain.Entities;
using PersonalExpenseTracking.Domain.Repositories;
using PersonalExpenseTracking.Domain.Repositories.RefreshToken;
using PersonalExpenseTracking.Domain.Repositories.User;
using PersonalExpenseTracking.Domain.Security.Tokens;
using PersonalExpenseTracking.Exception.ExceptionsBase;

namespace PersonalExpenseTracking.Application.Services
{
    public class UseRefreshTokenService : IUseRefreshTokenService
    {
        private const int ExpirationTimeInDays = 7;

        private readonly IRefreshTokenReadOnlyRepository _refreshTokenReadOnlyRepository;
        private readonly IRefreshTokenWriteOnlyRepository _refreshTokenWriteOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IAccessTokenGenerator _accessTokenGenerator;
        private readonly IRefreshTokenGenerator _refreshTokenGenerator;
        private readonly IUnitOfWork _unitOfWork;

        public UseRefreshTokenService(
            IRefreshTokenReadOnlyRepository refreshTokenReadOnlyRepository,
            IRefreshTokenWriteOnlyRepository refreshTokenWriteOnlyRepository,
            IUserReadOnlyRepository userReadOnlyRepository,
            IAccessTokenGenerator accessTokenGenerator,
            IRefreshTokenGenerator refreshTokenGenerator,
            IUnitOfWork unitOfWork)
        {
            _refreshTokenReadOnlyRepository = refreshTokenReadOnlyRepository;
            _refreshTokenWriteOnlyRepository = refreshTokenWriteOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
            _accessTokenGenerator = accessTokenGenerator;
            _refreshTokenGenerator = refreshTokenGenerator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResponseTokensJson> UserRefreshToken(RequestNewTokenJson request)
        {
            var refreshToken = await _refreshTokenReadOnlyRepository.Get(request.RefreshToken);
            if (refreshToken is null)
                throw new RefreshTokenExpiredException();

            var isValid = refreshToken.CreatedAt.AddDays(ExpirationTimeInDays) >= DateTime.UtcNow;
            if (isValid == false)
                throw new RefreshTokenExpiredException();

            var user = await _userReadOnlyRepository.GetById(refreshToken.UserId);

            var newRefreshToken = new RefreshToken
            {
                Value = _refreshTokenGenerator.Generate(),
                UserId = refreshToken.UserId
            };

            await _refreshTokenWriteOnlyRepository.Replace(newRefreshToken);

            await _unitOfWork.Commit();

            return new ResponseTokensJson
            {
                AccessToken = _accessTokenGenerator.Generate(user!),
                RefreshToken = newRefreshToken.Value
            };
        }
    }
}
