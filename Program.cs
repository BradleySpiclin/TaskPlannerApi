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
            var MyAllowedOrigins = "_myAllowedOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowedOrigins, policy =>
                {
                    policy.WithOrigins("https://localhost:3000")
                    .AllowAnyHeader()
                    .AllowAnyMethod();
                });
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();                        


            var app = builder.Build();

            app.UseRouting();

            app.UseAuthorization();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseCors(MyAllowedOrigins);
            app.Run();
        }
    }
}