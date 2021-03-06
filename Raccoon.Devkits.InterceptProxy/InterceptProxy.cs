﻿using Microsoft.Extensions.DependencyInjection;
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
        public IInterceptor[] Interceptors { get; private set; } = null!;
        public Type[] InterceptorTypes { get; private set; } = null!;

        protected override object? Invoke(MethodInfo? targetMethod, object?[]? args) =>
            Execute(Target, targetMethod!, args, Interceptors);

        private object? Execute(object target, MethodInfo targetMethod, object?[]? args, IEnumerable<IInterceptor> interceptors)
            => interceptors.Count() switch
            {
                0 => targetMethod.Invoke(target,args),
                _ => interceptors.First().OnExecuting(target,targetMethod,args,
                    ()=>Execute(target, targetMethod, args, interceptors.Skip(1)))
            };
        
        
        public static TIService CreateProxy(Type implementType, IServiceProvider serviceProvider, TIService target, params Type[]? interceptorTypes)
        {
            InterceptProxy<TIService> proxy = (Create<TIService, InterceptProxy<TIService>>()
                as InterceptProxy<TIService>)!;
            proxy._serviceProvider = serviceProvider;
            proxy.ImplementType = implementType;
            proxy.Target = target;
            var interceptorTypesFromInterface = typeof(TIService).GetCustomAttributes<InterceptorAttribute>()
                    .Select(item=>item.InterceptorType);
            var interceptorTypesFromImplementation = implementType.GetCustomAttributes<InterceptorAttribute>()
                    .Select(item=>item.InterceptorType); 
            proxy.InterceptorTypes = (interceptorTypes ?? Enumerable.Empty<Type>()).Concat(interceptorTypesFromInterface)
                .Concat(interceptorTypesFromImplementation).ToArray();

            proxy.Interceptors = proxy.InterceptorTypes.Select(item =>
                (serviceProvider.GetRequiredService(item) as IInterceptor)!).ToArray();
            return (proxy as TIService)!;

        }
    }
}
