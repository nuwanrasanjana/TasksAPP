
using Microsoft.EntityFrameworkCore;
using Tasks.Application.Interfaces.Services;
using Tasks.Application.Services;
using Tasks.Domain.Interfaces.Repositories;
using Tasks.Infrastructure.Context;
using Tasks.Infrastructure.Repositories;
using FluentValidation;
using Tasks.Domain.DTOs;
using Tasks.Application.DTOs;
using Tasks.Application.Validators;
using Tasks.Domain.Entities;

namespace Tasks.API
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
            builder.Services.AddScoped<ITaskItemsRepository,TaskItemsRepository>();
            builder.Services.AddScoped<ITaskItemsService,TaskItemsService>();
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("localConnectionString")));

            builder.Services.AddScoped<IValidator<CreateTaskItemDTO>, CreateTaskDTOValidator>();
            builder.Services.AddScoped<IValidator<TaskItem>, TaskItemValidator>();
            //builder.Services.AddFluentValidationAutoValidation(); // Enables auto validation

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader();
                });
            });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();
            app.UseCors("AllowAll");

            app.Run();
        }
    }
}
