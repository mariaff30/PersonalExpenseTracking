using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PersonalExpenseTracking.Api.Configuration;
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
            [FromServices] ILoginWithEmailAndPasswordUseCase useCase,
            [FromBody] RequestLoginJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpPost("token/refresh")]
        [ProducesResponseType(typeof(ResponseTokensJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> UseRefreshToken(
            [FromServices] IUseRefreshTokenUseCase useCase,
            [FromBody] RequestNewTokenJson request)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpGet("external-login/google/start")]
        public async Task<IActionResult> StartGoogleLogin(
            [FromQuery] string client,
            [FromServices] IOptions<ExternalLoginReturnUrlOptions> externalLoginReturnUrlOptions,
            [FromServices] ILoginWithExternalProviderUseCase useCase)
        {
            var auth = await Request.HttpContext.AuthenticateAsync(GoogleOpenIdConnectDefaults.AuthenticationScheme);
            if (auth.Succeeded == false)
                return Challenge(GoogleOpenIdConnectDefaults.AuthenticationScheme);

            var claims = auth.Principal!.Identities.First().Claims;

            var email = claims.FirstOrDefault(c => c.Type.Equals(ClaimTypes.Email))!.Value;
            var name = claims.FirstOrDefault(c => c.Type.Equals("name"))!.Value;

            var code = await useCase.Execute(new ExternalLoginInfo(name, email));

            await Request.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            var frontEndBase = client?.ToLowerInvariant() switch
            {
                "site" => externalLoginReturnUrlOptions.Value.Site,
                "app" => externalLoginReturnUrlOptions.Value.App,
                _ => null
            };

            if (frontEndBase.IsEmpty())
                return BadRequest();

            return Redirect($"{frontEndBase}?code={code}");
        }

        [HttpPost("external-login/exchange")]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ExchangeExternalLoginCode(
            [FromBody] RequestExternalLoginJson request,
            [FromServices] IExchangeExternalLoginCodeUseCase useCase)
        {
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpPost("password-recovery")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        public async Task<IActionResult> PasswordRecovery(
            [FromServices] IRequestPasswordRecoveryCodeUseCase useCase,
            [FromBody] RequestPasswordRecoveryJson request)
        {
            await useCase.Execute(request);

            return Accepted();
        }

        [HttpPost("password-recovery/reset")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ResetPassword(
            [FromServices] IResetPasswordUseCase useCase,
            [FromBody] RequestResetPasswordJson request)
        {
            await useCase.Execute(request);

            return NoContent();
        }
    }
}
