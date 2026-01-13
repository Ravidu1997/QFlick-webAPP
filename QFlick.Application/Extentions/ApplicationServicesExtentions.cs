using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using QFlick.Application.Abstractions;
using QFlick.Application.Services;
using QFlick.Application.Validators.Auth;

namespace QFlick.Application.Extentions
{
    public static class ApplicationServicesExtentions
    {
        //Register all Application services dependencies.
        public static IServiceCollection AddApplicationServicesExtentions(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IBusinessService, BusinessService>();

            //services.AddScoped<IValidator<LoginInputDto>, LoginInputDtoValidator>();

            services.AddValidatorsFromAssemblyContaining<LoginInputDtoValidator>();

            return services;
        }
    }
}
