/*using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Options;

namespace BuberDinner.API.Errors
{
    public class BuberDinnerProblemDetailsFactory : ProblemDetailsFactory
    {
        private readonly ApiBehaviorOptions _options;

        public BuberDinnerProblemDetailsFactory(IOptions<ApiBehaviorOptions> options)
        {
            _options = options?.Value ?? throw new ArgumentNullException();
        }

        public BuberDinnerProblemDetailsFactory()
        {
            
        }
        public override ProblemDetails CreateProblemDetails(
            HttpContext httpContext,
            int? statusCode = null,
            string? title = null,
            string? type = null,
            string? detail = null,
            string? instance = null)
        {
            ApplyProblemDetailsDefaults(httpContext, detail) ;
        }

        
        public override ValidationProblemDetails CreateValidationProblemDetails(HttpContext httpContext, ModelStateDictionary modelStateDictionary, int? statusCode = null, string? title = null, string? type = null, string? detail = null, string? instance = null)
        {
            throw new NotImplementedException();
        }
    }
}
*/