using Microservices.Category.Repositories.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microservices.Category
{
    public static class ConfigurationService
    {
        public static IServiceCollection MicroservicesCategoryConfigurationService(this IServiceCollection servicesCollection)
        {
            servicesCollection.AddSingleton<ICategoryRepository, CategoryRepository>();
            return servicesCollection;
        }
    }
}
