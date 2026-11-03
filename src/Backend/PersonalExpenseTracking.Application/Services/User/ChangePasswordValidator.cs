using FluentValidation;
using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.Services.Shared.Validator;

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
