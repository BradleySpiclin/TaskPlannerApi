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



            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "MyPolicy",
                    policy =>
                    {
                        policy.WithOrigins("https://localhost:3000")
                            .WithMethods("PUT", "DELETE", "GET", "POST");
                    });
            });

            var app = builder.Build();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseCors();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();
            app.Run();
        }
    }
}