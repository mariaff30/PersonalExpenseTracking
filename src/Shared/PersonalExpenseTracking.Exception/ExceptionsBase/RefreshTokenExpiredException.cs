using System.Net;

namespace PersonalExpenseTracking.Exception.ExceptionsBase
{
    public class RefreshTokenExpiredException : PersonalExpenseTrackingException
    {
        public override List<string> GetErrorMessages() => [ResourceMessagesException.EXPIRED_REFRESH_TOKEN];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;
    }
}
