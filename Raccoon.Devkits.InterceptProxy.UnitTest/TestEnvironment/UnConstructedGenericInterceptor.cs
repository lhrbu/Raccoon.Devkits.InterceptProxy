using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy.UnitTest.TestEnvironment
{
    public class UnConstructedGenericInterceptor<TIService> : Interceptor<TIService>
        where TIService : class
    {
        public override object? OnExecuting(TIService target, MethodInfo targetMethod, object?[]? args, Func<object?> next)
        {
            Console.WriteLine("Before: UnCtor Generic test!");
            object? result = next();
            Console.WriteLine("After: UnCtor Generic test ");
            return result;
        }
    }
}
