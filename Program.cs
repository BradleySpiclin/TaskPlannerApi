using Microsoft.EntityFrameworkCore;
using System;
using TaskPlannerApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.OpenApi.Models;

namespace TaskPlannerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();
            var connection = builder.Configuration.GetConnectionString("AZURE_SQL_CONNECTIONSTRING");

            // DbContext configuration
            builder.Services.AddDbContext<TaskContext>(options => options.UseSqlServer(connection));
            builder.Services.AddEndpointsApiExplorer();

            // Configure Swagger
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });
            });

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

    
            app.UseRouting();

            app.UseAuthorization();

            // Disable CORS
            app.Use((context, next) =>
            {
                context.Response.Headers.Remove("Access-Control-Allow-Origin");
                context.Response.Headers.Remove("Access-Control-Allow-Headers");
                context.Response.Headers.Remove("Access-Control-Allow-Methods");
                return next();
            });

            // Enable Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });

            app.MapControllers();
            app.Run();
        }
    }
}