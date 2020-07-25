using System.Linq;
using Geocoding;
using LogicLib;
using LogicLib.Services;
using LogicLib.Services.Docs;
using LogicLib.Services.Impl;
using LogicLib.Services.Impl.Docs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Web_Api.StartupTasks;

namespace Web_Api.Installers
{
    public class ServicesInstaller : IServiceInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration, IWebHostEnvironment env,ILogger logger)
        {
            services.AddSingleton<IGeocoderService, GoogleGeocoderService>(x =>
                new GoogleGeocoderService(configuration["GoogleGeocoderServiceApiKey"]));

            services.AddScoped<IAuthenticationService, AuthenticationService>();
            services.AddScoped<IEmployeesService, EmployeeService>();
            services.AddScoped<IUserDataService, UserDataService>();
            services.AddScoped<IProductsService, ProductsService>();
            //documents services
            services.AddScoped<IQuotationService, QuotationsService>();
            services.AddScoped<IInvoiceService, InvoicesService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<ICreditNotesService, CreditNotesService>();
            services.AddScoped<IDeliveryNotesService, DeliveryNotesService>();
            services.AddScoped<IDownPaymentRequestsService, DownPaymentRequestsService>();
            services.AddScoped<IUserLocationService, UserLocationService>();
            services.AddScoped<IEmployeeTimeClockService, EmployeeTimeClockService>();
            services.AddScoped<IActivityService, ActivityService>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IAttachmentsService, AttachmentsService>();
            services.AddScoped<IBusinessPartnerService, BusinessPartnerService>();
            
            
            services.AddTransient<MockDbAllocatorStartup>();
            
            
            typeof(IActionService).Assembly.ExportedTypes
                //.Where(x =>x.BaseType != null &&   x.GetInterfaces().Any(i=>i.IsGenericType && typeof(IActionService<>).IsAssignableFrom(i.GetGenericTypeDefinition())) && !x.IsInterface && !x.IsAbstract)

               .Where(x => typeof(IActionService).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                .ToList().ForEach(x=>  services.AddScoped(x));

         //   services.AddScoped<ILeadUserDataService, LeadUserDataService>();

            

        }
    }
}