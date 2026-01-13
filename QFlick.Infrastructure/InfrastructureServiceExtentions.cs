using FirebaseAdmin;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QFlick.Application.Abstractions;
using QFlick.Application.Interfaces;
using QFlick.Domain.Interfaces;
using QFlick.Infrastructure.Persistence;
using QFlick.Infrastructure.Repositories;
using QFlick.Infrastructure.Services;
using Google.Apis.Auth.OAuth2;
using QFlick.Infrastructure.Authentication;

namespace QFlick.Infrastructure
{
    public static class InfrastructureServiceExtentions
    {
        //Register all Infrastructure services dependencies.
        public static IServiceCollection AddInfrastructureDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultString");

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IAuthService, AuthService>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IBusinessRepostiory, BusinessRepostiory>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            FirebaseApp.Create(new AppOptions
            {
                Credential = GoogleCredential.FromFile("firebase.json")
            });

            services.AddSingleton<IAuthenticationService, AuthenticationService>();

            /*services.AddAuthorization();

             services.AddAuthentication()
                    .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
                    {
                        opt.Authority = configuration["JWTSettings:ValidIssuer"];
                        opt.Audience = configuration["JWTSettings:Audience"];
                        opt.TokenValidationParameters.ValidIssuer = configuration["JWTSettings:ValidIssuer"];
                    });*/

            return services;
        }
    }
}
