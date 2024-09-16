using BuberDinner.Application.Common.Errors;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.API.Controllers
{
    public class ErrorsController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

            var (statuscode, message) = exception switch
            {
                IServiceException service => ((int)service.StatusCode, service.ErrorMessage), 
                _ => (StatusCodes.Status500InternalServerError, "Internal Server Error")
            };
            //return Problem(title:exception?.Message);
            //return Problem(title:exception?.Message,statusCode:400);
            //return Problem(statusCode: 400);
            //return Problem();
            return Problem(statusCode: statuscode, title:message);
        }
    }
}
