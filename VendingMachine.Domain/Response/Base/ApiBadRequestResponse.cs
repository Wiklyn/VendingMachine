using FluentValidation.Results;

namespace VendingMachine.Domain.Response.Base
{
    public class ApiBadRequestResponse
    {
        public string? Message { get; set; }
        List<string> ValidationErrors { get; set; } = [];

        public ApiBadRequestResponse(string message)
        {
            Message = message;
        }

        public ApiBadRequestResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                ValidationErrors.Add(error.ErrorMessage);
            }

            Message = ValidationErrors[0];
        }
    }
}
