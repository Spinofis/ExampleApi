using Microsoft.Extensions.DependencyInjection;
using SignalRChatV1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChatV1
{
    public static class ServiceCollectionExtension
    {
        public static void AddCustomServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<MessageService>();
        }
    }
}
