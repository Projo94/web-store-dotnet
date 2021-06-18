using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.WebStore.Application.Contracts.Infrastructure;
using WebApp.WebStore.Application.Models.Mail;
using WebApp.WebStore.Infrastructure.Mail;


namespace WebApp.WebStore.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            //  services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));

            services.AddTransient<ICsvExporter, CsvExporter>();
            services.AddTransient<IEmailService, EmailService>();

            return services;
        }
    }
}
