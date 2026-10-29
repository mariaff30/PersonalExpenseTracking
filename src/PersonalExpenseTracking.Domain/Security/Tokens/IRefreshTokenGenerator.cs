namespace PersonalExpenseTracking.Domain.Security.Tokens;

public interface IRefreshTokenGenerator
{
    string Generate();
}
