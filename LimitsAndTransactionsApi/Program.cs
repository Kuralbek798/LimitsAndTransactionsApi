
using Autofac;
using Autofac.Extensions.DependencyInjection;
using LimitsAndTransactionsApi.Context;
using LimitsAndTransactionsApi.Mapper;
using Microsoft.EntityFrameworkCore;
using System;

namespace LimitsAndTransactionsApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            // DbContext
            builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Services Registr
            var containerBuilder = new ContainerBuilder();
            // Populate would automatically register services with life scope defined in .Net Core
            containerBuilder.Populate(builder.Services);
            DependencyInjectionConfig.RegisterServices(containerBuilder);

            var container = containerBuilder.Build();

            var app = builder.Build();

            //  HTTP middleware configurrations
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
