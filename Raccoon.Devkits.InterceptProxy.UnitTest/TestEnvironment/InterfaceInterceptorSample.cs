using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy.UnitTest.TestEnvironment
{
    public class InterfaceInterceptorSample : IInterceptor
    {
        public object? OnExecuting(object target, MethodInfo targetMethod, object?[]? args, Func<object?> next)
        {
            Console.WriteLine("Before: Interface test!");
            object? result = next();
            Console.WriteLine("After: Interface test ");
            return result;
        }
    }
}
