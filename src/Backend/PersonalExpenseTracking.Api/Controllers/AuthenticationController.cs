using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.DTOs.Response;
using PersonalExpenseTracking.Application.Interfaces;

namespace dotnet_order_management_api.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {

        [HttpPost("login")]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login(
            [FromServices] ILoginWithEmailAndPasswordService useCase,
            [FromBody] RequestLoginJson request)
        {
            var response = await useCase.LoginWithEmailAndPassword(request);

            return Ok(response);
        }

        [HttpPost("token/refresh")]
        [ProducesResponseType(typeof(ResponseTokensJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UseRefreshToken(
            [FromServices] IUseRefreshTokenService useCase,
            [FromBody] RequestNewTokenJson request)
        {
            var response = await useCase.UserRefreshToken(request);

            return Ok(response);
        }

        [HttpPost("password-recovery")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> PasswordRecovery(
            [FromServices] IRequestPasswordRecoveryCodeService useCase,
            [FromBody] RequestPasswordRecoveryJson request)
        {
            await useCase.PasswordRecovery(request);

            return Accepted();
        }

        [HttpPost("password-recovery/reset")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPassword(
            [FromServices] IResetPasswordService useCase,
            [FromBody] RequestResetPasswordJson request)
        {
            await useCase.ResetPassword(request);

            return NoContent();
        }
    }
}
