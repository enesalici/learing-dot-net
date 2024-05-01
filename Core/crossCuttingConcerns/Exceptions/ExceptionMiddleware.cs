using Core.crossCuttingConcerns.Exceptions.HttpProblemDetails;
using Core.crossCuttingConcerns.Exceptions.Types;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Core.crossCuttingConcerns.Exceptions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception exception)
            {
                context.Response.ContentType = "application/json";
                context.Response.StatusCode = StatusCodes.Status400BadRequest;


                if(exception is BusinessException)
                {
                    ProblemDetails problemDetails = new ProblemDetails();
                    problemDetails.Title = "business rule validation";
                    problemDetails.Detail = exception.Message;
                    problemDetails.Type = "BusinessException";
                    await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
                    
                }
                else
                {
                    context.Response.StatusCode = StatusCodes.Status500InternalServerError;

                }
                



            }
        }
    }
}
