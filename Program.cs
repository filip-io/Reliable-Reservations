using DotNetEnv;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Reliable_Reservations.Data;
using Reliable_Reservations.Data.Repos;
using Reliable_Reservations.Data.Repos.IRepos;
using Reliable_Reservations.Services;
using Reliable_Reservations.Services.IServices;
using System.Text;
using System.Text.Json.Serialization;

namespace Reliable_Reservations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            Env.Load();
            var connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING");

            // Configure logging
            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();
            builder.Logging.AddDebug();

            // Add services to the container.
            builder.Services.AddDbContext<ReliableReservationsDbContext>(
                options => options.UseSqlServer(connectionString).EnableSensitiveDataLogging()
            );

            // User
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<IAdminRepository, AdminRepository>();

            // Customer
            builder.Services.AddScoped<ICustomerService, CustomerService>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();

            // OpeningHours
            builder.Services.AddScoped<IOpeningHoursService, OpeningHoursService>();
            builder.Services.AddScoped<IOpeningHoursRepository, OpeningHoursRepository>();

            // Reservation
            builder.Services.AddScoped<IReservationService, ReservationService>();
            builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

            // Table
            builder.Services.AddScoped<ITableService, TableService>();
            builder.Services.AddScoped<ITableRepository, TableRepository>();

            // TimeSlot
            builder.Services.AddScoped<ITimeSlotService, TimeSlotService>();
            builder.Services.AddScoped<ITimeSlotRepository, TimeSlotRepository>();

            // MenuItem
            builder.Services.AddScoped<IMenuItemService, MenuItemService>();
            builder.Services.AddScoped<IMenuItemRepository, MenuItemRepository>();

            builder.Services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("LocalReact", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Environment.GetEnvironmentVariable("JWT__ISSUER"),
                        ValidAudience = Environment.GetEnvironmentVariable("JWT__AUDIENCE"),
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT__KEY") ?? throw new InvalidOperationException("JWT__KEY is not configured.")))
                    };
                });

            builder.Services.AddAuthorization();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // AutoMapper
            builder.Services.AddAutoMapper(typeof(Program));

            var app = builder.Build();

            app.UseCors("LocalReact");

            app.UseAuthentication();
            app.UseAuthorization();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.MapControllers();

            app.Run();
        }
    }
}