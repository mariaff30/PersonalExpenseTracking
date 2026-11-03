namespace PersonalExpenseTracking.Application.DTOs.Response
{
    public class ResponseExpenseUser
    {
        public required string Category { get; set; }
        public required string Description { get; set; }
        public float Price { get; private set; }
    }
}
