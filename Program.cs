using Microsoft.CodeAnalysis.Host.Mef;
using Microsoft.EntityFrameworkCore;
using System;
using TaskPlannerApi.Models;

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
            builder.Services.AddCors();

            var app = builder.Build();

            app.UseCors(options =>
            {
                options.WithOrigins("http://localhost:3000");
            });

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.Run();
        }
    }
}