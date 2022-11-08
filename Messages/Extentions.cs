using MediatR;
using Messages.Client;
using Messages.ClientServer;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Messages
{
    public static class Extentions
    {
        public static IServiceCollection AddServerServices(this IServiceCollection services, Assembly assembly )
        {
            return services.AddMediatR(assembly).AddTransient<IAPIBus, APIServerBus>();
        }
        public static IServiceCollection AddClientServices(this IServiceCollection services, Assembly assembly)
        {
            services.AddMediatR(assembly);
            services.AddTransient<PublisherGateway>();
            services.AddTransient<IAPIBus, APIClientBus>();
            return services.AddSingleton<IUIBus,UIBus>();
        }
    }
}
