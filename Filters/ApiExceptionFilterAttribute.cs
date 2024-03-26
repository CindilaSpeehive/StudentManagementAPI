using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using StudentManagementAPI.Exceptions;

namespace StudentManagementAPI.Filters
{
    public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if(context.Exception is NotFoundCustomException)
            {
                var details = new ProblemDetails
                {
                    Status = StatusCodes.Status404NotFound,
                    Title = "new",
                    Type = "https://tools.ietf.org/html/rfc7235#section-3.1",
                    Detail = context.Exception.Message

                };

                context.Result = new ObjectResult(details);

                context.ExceptionHandled = true;


            }
        }
    }
}
