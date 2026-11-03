using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.DTOs.Response;

namespace PersonalExpenseTracking.Application.Interfaces
{
    public interface IUseRefreshTokenService
    {
        Task<ResponseTokensJson> UserRefreshToken(RequestNewTokenJson request);
    }
}
