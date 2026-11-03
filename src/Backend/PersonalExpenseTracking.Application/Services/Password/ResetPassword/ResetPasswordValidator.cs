using FluentValidation;
using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Application.Services.Shared.Validator;

namespace PersonalExpenseTracking.Application.Services.Password.ResetPassword
{
    public class ResetPasswordValidator : AbstractValidator<RequestResetPasswordJson>
    {
        public ResetPasswordValidator()
        {
            RuleFor(request => request.NewPassword).Password();
        }
    }
}
