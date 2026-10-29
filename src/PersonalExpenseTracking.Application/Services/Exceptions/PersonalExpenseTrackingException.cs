using System.Net;

namespace PersonalExpenseTracking.Application.Services.Exceptions
{
    public abstract class PersonalExpenseTrackingException : System.Exception
    {
        public abstract HttpStatusCode GetStatusCode();
        public abstract List<string> GetErrorMessages();
    }
}
