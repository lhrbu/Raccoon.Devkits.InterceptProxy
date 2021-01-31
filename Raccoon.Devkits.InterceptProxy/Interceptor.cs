using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy
{
    public abstract class Interceptor<TIService> : IInterceptor where TIService : class
    {
        public abstract object? OnExecuting(TIService target, MethodInfo targetMethod, object?[]? args, Func<object?> next);
        public object? OnExecuting(object target, MethodInfo targetMethod, object?[]? args,
            Func<object?> next) =>
            OnExecuting((target as TIService)??throw new ArgumentException($"target is not {typeof(TIService)}",nameof(target)), 
                targetMethod, args, next);


    }
}
