using DadJokesAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace DadJokesAPI.Middleware
{
    /// <summary>
    /// Implemented a Middleware to handle the Exception Globally
    /// </summary>
    public class ExceptionMiddleware : IMiddleware
    {
        //Injection of logger
        private readonly ILogger<ExceptionMiddleware> _logger;
        public ExceptionMiddleware(ILogger<ExceptionMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError("Something went wrong");
                await HandleException(context, ex);
            }
        }
        /// <summary>
        /// Handling exception globally depends on Context and Exception
        /// </summary>
        /// <param name="context"></param>
        /// <param name="ex"></param>
        /// <returns></returns>
        private static Task HandleException(HttpContext context, Exception ex)
        {
            var errorResponse = new ErrorResponse
            {
                StatuCode = (int)HttpStatusCode.InternalServerError,
                Message = ex.Message
            };
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            return context.Response.WriteAsync(errorResponse.ToString());
        }
    }
}
