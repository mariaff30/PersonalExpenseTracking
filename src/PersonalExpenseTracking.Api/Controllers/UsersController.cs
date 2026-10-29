using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.DTOs.Response;
using PersonalExpenseTracking.Application.Interfaces;
using PersonalExpenseTracking.Application.Interfaces.User;

namespace dotnet_order_management_api.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredUserJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterUserAccountService useCase,
            [FromBody] RequestRegisterUserAccountJson request)
        {
            var result = await useCase.RegisterUserAccount(request);

            return Created(string.Empty, result);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ResponseUserProfileJson), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetUserProfile([FromServices] IGetUserProfileService useCase)
        {
            var result = await useCase.GetUserProfile();

            return Ok(result);
        }

        [HttpPut("profile")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateProfile(
            [FromServices] IUpdateUserService useCase,
            [FromBody] RequestUpdateUserJson request)
        {
            await useCase.UpdateUser(request);

            return NoContent();
        }

        [HttpPut("password")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdatePassword(
            [FromServices] IChangePasswordService useCase,
            [FromBody] RequestChangePasswordJson request)
        {
            await useCase.Execute(request);

            return NoContent();
        }

        [HttpDelete]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAccount([FromServices] IDeleteUserAccountService useCase)
        {
            await useCase.DeleteUserAccount();

            return NoContent();
        }
    }
}
