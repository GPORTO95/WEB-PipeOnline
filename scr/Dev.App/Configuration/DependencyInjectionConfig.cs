using Dev.App.Extensions;
using Dev.Business.Interfaces;
using Dev.Business.Notifications;
using Dev.Business.Services;
using Dev.Data.Context;
using Dev.Data.Repository;
using KissLog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.DependencyInjection;

namespace Dev.App.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<IProspectRepository, ProspectRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ISegmentRepository, SegmentRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ITotvsRepository, TotvsRepository>();
            services.AddScoped<IProspectEmployeeRepository, ProspectEmployeeRepository>();
            services.AddSingleton<IValidationAttributeAdapterProvider, CoinValidationAttributeAdapterProvider>();

            services.AddScoped<INotifier, Notifier>();
            services.AddScoped<IProspectService, ProspectService>();
            services.AddScoped<ICustomerService, CustomerService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //services.AddScoped<ILogger>((context) =>
            //{
            //    return Logger.Factory.Get();
            //});

            return services;
        }
    }
}
