using PersonalExpenseTracking.Domain.Entities;

namespace PersonalExpenseTracking.Domain.Security.Tokens;

public interface IAccessTokenGenerator
{
    string Generate(User user);
}