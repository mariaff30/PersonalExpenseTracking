namespace PersonalExpenseTracking.Application.DTOs.Response
{
    public class ResponseRegisteredUserJson
    {
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public ResponseTokensJson Tokens { get; set; } = new ResponseTokensJson();
    }
}
