using Appeal.Data.Abstract;
using Appeal.Data.Concrete;
using Appeal.Services.Abstract;
using Appeal.Services.Concrete;
using Appeal.Shared.Data.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Appeal.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadMyServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<DBClient>();
            serviceCollection.AddScoped<IAppealService, AppealManager>();
            serviceCollection.AddScoped<IFileService, FileManager>();
            serviceCollection.AddScoped<IOrganizationService, OrganizationManager>();
            serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();

            return serviceCollection;
        }
    }
}
