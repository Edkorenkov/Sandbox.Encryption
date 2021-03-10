using System;
using System.Linq;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ConfigurationExtensions
    {
        public static T GetEncryptionService<T>(this IServiceProvider serviceProvider, string serviceName)
        {
            return serviceProvider
                .GetServices<T>()
                .First(x => x.GetType().Name.StartsWith(serviceName));
        }
    }
}
