using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Raccoon.Devkits.InterceptProxy
{
    public class InterceptProxy<TIService> : DispatchProxy
        where TIService : class
    {

        private IServiceProvider _serviceProvider = null!;
        public TIService Target { get; private set; } = null!;
        public Type ImplementType { get; private set; } = null!;
        public IInterceptor[]? Interceptors { get; private set; }
        public Type[]? InterceptorTypes { get; private set; }
        
        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args)
        {
            if (Interceptors is null) { return targetMethod!.Invoke(Target, args); }
            else
            {
                foreach (var interceptor in Interceptors)
                { interceptor.BeforeExecute(Target, targetMethod!, args);}
                object? result = targetMethod?.Invoke(Target, args);
                foreach (var interceptor in Interceptors)
                { interceptor.AfterExecute(Target, targetMethod!, args, result); }
                return result;
            }
        }

        public static TIService CreateProxy(Type implementType, IServiceProvider serviceProvider, TIService target, params Type[]? interceptorTypes)
        {
            InterceptProxy<TIService> proxy = (Create<TIService, InterceptProxy<TIService>>()
                as InterceptProxy<TIService>)!;
            proxy._serviceProvider = serviceProvider;
            proxy.ImplementType = implementType;
            proxy.Target = target;
            proxy.InterceptorTypes = interceptorTypes;
            proxy.Interceptors = interceptorTypes?.Select(item =>
                (serviceProvider.GetRequiredService(item) as IInterceptor)!).ToArray();
            return (proxy as TIService)!;

        }
    }
}
