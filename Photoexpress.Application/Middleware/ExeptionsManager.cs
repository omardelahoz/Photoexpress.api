using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Photoexpress.Application.Exceptions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Photoexpress.Application.Middleware
{
    public class ExeptionsManager
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExeptionsManager> _logger;
        private readonly IHostEnvironment _env;

        public ExeptionsManager(RequestDelegate next, ILogger<ExeptionsManager> logger, IHostEnvironment env)
        {
            _next = next;
            _logger = logger;
            _env = env;
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (PhotoexpressException iex)
            {
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new Responses.Base()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = iex.Message,
                    Result = false,
                    Errors = iex.Errors
                }));
            }
            catch (Exception ex)
            {
                string textoMensaje = ex.Message;

                Exception e = ex;
                while (e.InnerException != null)
                {
                    textoMensaje += " - InnerException - " + e.InnerException.Message;
                    e = e.InnerException;
                }

                textoMensaje += " - StackTrace - " + ex.StackTrace;
                httpContext.Response.ContentType = "application/json";
                httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;

                _logger.LogError(
                   "Request {method} {url} => {statusCode} - Mensaje de error: {textoMensaje}",
                   httpContext.Request?.Method,
                   httpContext.Request?.Path.Value,
                   httpContext.Response?.StatusCode,
                   textoMensaje);

#if (DEBUG)
                await httpContext.Response!.WriteAsync(JsonConvert.SerializeObject(new Responses.Base()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = textoMensaje,
                    Result = false
                }));
#else
            await httpContext.Response.WriteAsync(JsonConvert.SerializeObject(new Responses.Base()
                {
                    Status = StatusCodes.Status400BadRequest,
                    Message = "Algo salió mal!, por favor contacta al administrador",
                    Result = false
                }));
#endif

            }
        }
    }
}
