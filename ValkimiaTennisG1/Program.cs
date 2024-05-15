using ValkimiaTennisG1.Configuration;
using ValkimiaTennisG1.Middlewares;
using ValkimiaTennisG1.Middlewares.MiddlewareService;
using ValkimiaTennisG1.Middlewares.MiddlewareService.Interfaces;
using ValkimiaTennisG1.Services;
using ValkimiaTennisG1.Services.Interfaces;

namespace ValkimiaTennisG1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

        
            builder.Services.AddTennisDbConfiguration();
  
            builder.Services.AddScoped<IPlayerService, PlayerService>();
            builder.Services.AddScoped<IExceptionService, ExceptionService>();

            builder.Services.AddScoped<ITournamentService, TournamentService>();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<CustomMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
