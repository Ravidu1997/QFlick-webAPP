using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using QFlick.Application.Exceptions;
using Serilog;

namespace QFlick_WebAPI.Infrastructure
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            Log.Error(exception, "Error Message:{message}, Occured at:{time}", exception.Message, DateTime.UtcNow);

            var problemDetails = exception switch
            {
                NotFoundException nf => new ProblemDetails
                {
                    Title = nf.GetType().Name,
                    Detail = nf.Message,
                    Status = StatusCodes.Status404NotFound
                },

                BadRequestException br => new ProblemDetails
                {
                    Title = br.GetType().Name,
                    Detail = br.Message,
                    Status = StatusCodes.Status400BadRequest
                },

                NullReferenceException nf => new ProblemDetails
                {
                    Title = nf.GetType().Name,
                    Detail = nf.Message,
                    Status = StatusCodes.Status500InternalServerError
                },

                _ => new ProblemDetails
                {
                    Title = exception.GetType().Name,
                    Detail = exception.Message,
                    Status = StatusCodes.Status500InternalServerError
                }
            };

            httpContext.Response.StatusCode = problemDetails.Status!.Value;

            await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

            return true;
        }
    }
}
