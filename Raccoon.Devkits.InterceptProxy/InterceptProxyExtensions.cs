using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy
{
    public static class InterceptProxyExtensions
    {
        public static IServiceCollection AddTransientProxy<TIService,TService>(this IServiceCollection services,params Type[]? interceptorTypes)
            where TIService:class
            where TService:class,TIService
            =>services.AddTransient<TService>().AddTransient<TIService>(serviceProvider =>
                RegisterProxy<TIService,TService>(serviceProvider,interceptorTypes));
        public static IServiceCollection AddScopedProxy<TIService, TService>(this IServiceCollection services, params Type[]? interceptorTypes)
            where TIService : class
            where TService : class, TIService
            => services.AddScoped<TService>().AddScoped<TIService>(serviceProvider => 
                    RegisterProxy<TIService, TService>(serviceProvider, interceptorTypes));
        public static IServiceCollection AddSingletonProxy<TIService, TService>(this IServiceCollection services, params Type[]? interceptorTypes)
            where TIService : class
            where TService : class, TIService
            => services.AddSingleton<TService>().AddSingleton<TIService>(serviceProvider =>
                    RegisterProxy<TIService, TService>(serviceProvider, interceptorTypes));


        private static TIService RegisterProxy<TIService, TService>(IServiceProvider serviceProvider, params Type[]? interceptorTypes)
            where TIService : class
            where TService : class, TIService
        {
            TService target = serviceProvider.GetRequiredService<TService>();
            return InterceptProxy<TIService>.CreateProxy(typeof(TService), serviceProvider, target, interceptorTypes);
        }
    }
}
