using FluentValidation;
using PersonalExpenseTracking.Application.DTOs.Request;

namespace PersonalExpenseTracking.Application.Services.User
{
    public class ChangePasswordValidator : AbstractValidator<RequestChangePasswordJson>
    {
        public ChangePasswordValidator()
        {
            RuleFor(request => request.NewPassword).Password();
        }
    }
}
