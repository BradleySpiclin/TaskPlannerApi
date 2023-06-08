using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.EntityFrameworkCore;
using System;
using TaskPlannerApi.Models;
using Microsoft.AspNetCore.Builder;

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
            builder.Services.AddSwaggerGen();

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

            app.MapControllers();

            app.Run();
        }
    }
}