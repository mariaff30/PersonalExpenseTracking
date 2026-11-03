using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalExpenseTracking.Application.DTOs.Response;
using PersonalExpenseTracking.Application.Interfaces;

namespace dotnet_order_management_api.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ExpensesController: ControllerBase
    {
        [HttpGet]
        [Authorize]
        [ProducesResponseType(typeof(ResponseExensesUser), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetExpensesUser([FromServices] IGetExpensesUser useCase, [FromBody] Guid idUser)
        {
            var result = await useCase.Execute();

            return Ok(result);
        }
    }
}
