using Lms.Domain.Interfaces;
using Lms.Application.Interfaces;
using Lms.Infrastructure.Repositories;
using Lms.Infrastructure.Services;
using Lms.Infrastructure.Utilities;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Data;
namespace Lms.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAuthorService, AuthorService>();
            services.AddTransient<IStudentService, StudentService>();
            services.AddTransient<ITransactionService, TransactionService>();
            services.AddTransient<IDashboardService, DashboardService>();
            

            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<IDashboardRepository, DashboardRepository>();
            services.AddScoped<JwtTokenHelper>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<INotificationService, NotificationService>();
            

            services.AddScoped(typeof(IErrorHandlingService<>), typeof(ErrorHandlingService<>));
            //configure JWT authentication middleware
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(opt =>
            {
                opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });

            return services;
        }
    }
}
