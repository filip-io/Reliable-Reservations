using Microsoft.EntityFrameworkCore;
using Reliable_Reservations.Data;
using Reliable_Reservations.Repos;
using Reliable_Reservations.Repos.IRepos;
using Reliable_Reservations.Repositories;
using Reliable_Reservations.Repositories.IRepos;
using Reliable_Reservations.Services;
using Reliable_Reservations.Services.IServices;

namespace Reliable_Reservations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            DotNetEnv.Env.Load();
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            // Configure logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            // Add services to the container.
            builder.Services.AddDbContext<ReliableReservationsDbContext>(
                options => options.UseSqlServer(connectionString));

            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<ITableService, TableService>();
            builder.Services.AddScoped<ITableRepository, TableRepository>();
            builder.Services.AddScoped<ITimeSlotService, TimeSlotService>();
            builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();
            builder.Services.AddScoped<IOpeningHoursService, OpeningHoursService>();
            builder.Services.AddScoped<IOpeningHoursRepository, OpeningHoursRepository>();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(typeof(Program));

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

            app.Run();
        }
    }
}