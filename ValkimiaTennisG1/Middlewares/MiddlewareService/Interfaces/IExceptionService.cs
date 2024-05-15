using ValkimiaTennisG1.Excepcion;

namespace ValkimiaTennisG1.Middlewares.MiddlewareService.Interfaces
{
    public interface IExceptionService
    {
        Task GetBadRequestExceptionResponseAsync(HttpContext context, BadRequestException badRequestException);
    }
}
