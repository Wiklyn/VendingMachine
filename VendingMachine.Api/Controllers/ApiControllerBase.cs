using Microsoft.AspNetCore.Mvc;
using OneOf;
using VendingMachine.Domain.Response.Base;

namespace VendingMachine.Api.Controllers
{
    public class ApiControllerBase : ControllerBase
    {
        [NonAction]
        public IActionResult ProcessError(OneOf<ApiNotFoundResponse, ApiBadRequestResponse> response)
        {
            return response.Value switch
            {
                ApiNotFoundResponse => NotFound(new ProblemDetails
                {
                    Title = "Not Found Error",
                    Detail = response.AsT0.Message,
                    Status = StatusCodes.Status404NotFound,
                    Type = response.AsT0.GetType().Name

                }),
                ApiBadRequestResponse => BadRequest(new ProblemDetails
                {
                    Title = "Bad Request Error",
                    Detail = response.AsT1.Message,
                    Status = StatusCodes.Status400BadRequest,
                    Type = response.AsT1.GetType().Name

                }),
                _ => NotFound()
            };
        }
    }
}
