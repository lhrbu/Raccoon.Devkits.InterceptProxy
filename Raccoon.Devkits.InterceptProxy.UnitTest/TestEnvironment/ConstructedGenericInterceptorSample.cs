using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy.UnitTest.TestEnvironment
{
    public class ConstructedGenericInterceptorSample : Interceptor<IServiceSample>
    {
        public override object? OnExecuting(IServiceSample target, MethodInfo targetMethod, object?[]? args, Func<object?> next)
        {
            Console.WriteLine("Before: Ctor Generic test!");
            object? result = next();
            Console.WriteLine("After: Ctor Generic test ");
            return result;
        }
    }
}
