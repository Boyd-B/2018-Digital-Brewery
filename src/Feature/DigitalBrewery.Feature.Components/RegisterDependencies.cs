using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using DigitalBrewery.Feature.Components.Controllers;
using DigitalBrewery.Feature.Components.Repositories;

namespace DigitalBrewery.Feature.Components
{
    public class RegisterDependencies: IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IComponentRepository, ComponentRepository>();
            serviceCollection.AddTransient<ComponentController>();

            serviceCollection.AddTransient<IComponentListRepository, ComponentListRepository>();
            serviceCollection.AddTransient<ListController>();
        }
    }
}