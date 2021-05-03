using Elmah.Io.AspNetCore;
using Microsoft.AspNetCore.Http;
using System;
using System.Net;
using System.Threading.Tasks;

namespace CompleteApp.Api.Extensions
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception e)
            {
                HandleException(httpContext, e);
            }
        }

        private static void HandleException(HttpContext httpContext, Exception exception)
        {
            //exception.Ship(httpContext);
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}
