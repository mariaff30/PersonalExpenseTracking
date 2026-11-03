using FluentValidation;
using PersonalExpenseTracking.Application.DTOs.Request;
using PersonalExpenseTracking.Domain.Extensions;
using PersonalExpenseTracking.Exception.ExceptionsBase;

namespace PersonalExpenseTracking.Application.Services.User
{
    public class RegisterUserAccountValidator : AbstractValidator<RequestRegisterUserAccountJson>
    {
        public RegisterUserAccountValidator()
        {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.VALIDATION_NAME_REQUIRED);
            RuleFor(user => user.Email).NotEmpty().WithMessage(ResourceMessagesException.VALIDATION_EMAIL_REQUIRED);
            When(user => user.Email.IsNotEmpty(), () =>
        {
            RuleFor(user => user.Email).EmailAddress().WithMessage(ResourceMessagesException.VALIDATION_EMAIL_INVALID);
        });
        }
    }
}
