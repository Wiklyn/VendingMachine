namespace VendingMachine.Domain.Response.Base
{
    public class ApiNotFoundResponse
    {
        public string Message { get; set; }

        public ApiNotFoundResponse(string message)
        {
            Message = message;
        }
    }
}
