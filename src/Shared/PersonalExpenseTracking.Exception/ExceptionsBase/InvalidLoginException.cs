using System.Net;

namespace PersonalExpenseTracking.Exception.ExceptionsBase
{
    public class InvalidLoginException : PersonalExpenseTrackingException
    {
        public override List<string> GetErrorMessages() => [ResourceMessagesException.VALIDATION_LOGIN_INVALID];

        public override HttpStatusCode GetStatusCode() => HttpStatusCode.Unauthorized;

    }
}
