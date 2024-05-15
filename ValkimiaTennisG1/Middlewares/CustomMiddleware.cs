using ValkimiaTennisG1.Excepcion;
using ValkimiaTennisG1.Middlewares.MiddlewareService.Interfaces;

namespace ValkimiaTennisG1.Middlewares
{
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<CustomMiddleware> _loger;

        public CustomMiddleware(RequestDelegate next, ILogger<CustomMiddleware> loger)
        {
            _next = next;
            _loger = loger;
        }

        public async Task Invoke(HttpContext context, IExceptionService exceptionService)
        {
            try
            {
                await _next(context);
            }
            catch (BadRequestException badRequestException)
            {
                await exceptionService.GetBadRequestExceptionResponseAsync(context, badRequestException);
            }
            catch (Exception ex)
            {
                //Alguna logica de que devolvemos en caso de que capturemos esa exception

                throw;
            }
        }
    }

}

