namespace PersonalExpenseTracking.Domain.Security.Tokens;

public interface IAccessTokenProvider
{
    string GetToken();
}