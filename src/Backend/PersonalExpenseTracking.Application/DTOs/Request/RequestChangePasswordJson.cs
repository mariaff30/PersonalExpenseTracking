namespace PersonalExpenseTracking.Application.DTOs.Request
{
    public class RequestChangePasswordJson
    {
        public string CurrentPassword { get; set; } = string.Empty;
        public string NewPassword { get; set; } = string.Empty;
    }
}
