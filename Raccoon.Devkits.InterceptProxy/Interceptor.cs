using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy
{
    public abstract class Interceptor<TIService> : IInterceptor where TIService : class
    {
        public abstract void BeforeExecute(TIService service, MethodInfo targetMethod, object?[]? args);
        public abstract void AfterExecute(TIService service, MethodInfo targetMethod, object?[]? args, object? result);

        public void BeforeExecute(object target, MethodInfo targetMethod, object?[]? args) =>
            BeforeExecute((target as TIService)!, targetMethod, args);

        public void AfterExecute(object target, MethodInfo targetMethod, object?[]? args, object? result) =>
            AfterExecute((target as TIService)!, targetMethod, args, result);
    }
}
