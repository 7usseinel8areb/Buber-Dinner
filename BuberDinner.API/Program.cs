
using BuberDinner.API.Filters;
using BuberDinner.API.Middleware;
using BuberDinner.Application;
using BuberDinner.Infrastructure;

namespace BuberDinner.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                //Injection
                builder.Services.AddApplication()
                                .AddInfrastructure(builder.Configuration);
                // Add services to the container.
                builder.Services.AddControllers(options =>
                {
                    //Let this filter work with all the controllers
                    options.Filters.Add<ErrorHandlingFilterAttribute>();
                });

                // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
            }


            

            var app = builder.Build();
            {
                // Configure the HTTP request pipeline.
                if (app.Environment.IsDevelopment())
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                //app.UseMiddleware<ErrorHandlingMiddleware>();
                app.UseHttpsRedirection();

                /*app.UseAuthorization();*/

                app.MapControllers();

                app.Run();
            }
            
        }
    }
}
