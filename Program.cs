using Microsoft.EntityFrameworkCore;
using System;
using TaskPlannerApi.Data;
using TaskPlannerApi.Repositories.Contracts;
using TaskPlannerApi.Repositories;
using Microsoft.AspNetCore.Builder;
using TaskPlannerApi.Models;

namespace TaskPlannerApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            {
                builder.Services.AddControllers();
                builder.Services.AddEndpointsApiExplorer();
                builder.Configuration.AddUserSecrets<StartupBase>();
                var connectionString = builder.Configuration["ConnectionStrings:AZURE_SQL_CONNECTIONSTRING"];
                builder.Services.AddDbContext<AppDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);

                });
                builder.Services.AddEndpointsApiExplorer();
                builder.Services.AddSwaggerGen();
                builder.Services.AddScoped<TaskItemRepository>();
                builder.Services.AddScoped<CategoryRepository>();

                builder.Services.AddCors(options =>
                {
                    options.AddDefaultPolicy(builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
                });
            }
            var app = builder.Build();
            {
                AppDbInitializer.SeedDatabase(app);
                app.UseHttpsRedirection();
                app.MapControllers();
                app.UseCors();

                if (app.Environment.IsDevelopment()) 
                {
                    app.UseSwagger();
                    app.UseSwaggerUI();
                }
                app.Run();
            }
        }
    }
}