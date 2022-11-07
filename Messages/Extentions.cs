using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Messages
{
    public static class Extentions
    {
        public static IServiceCollection AddServerServices(this IServiceCollection services, Assembly assembly )
        {
            return services.AddMediatR(assembly).AddTransient<IBus, Bus>();
        }
        public static IServiceCollection AddClientServices(this IServiceCollection services, Assembly assembly)
        {
            return services.AddMediatR(assembly).AddTransient<PublisherGateway>().AddTransient<IBus, RemoteableBus>();
        }
    }
}
