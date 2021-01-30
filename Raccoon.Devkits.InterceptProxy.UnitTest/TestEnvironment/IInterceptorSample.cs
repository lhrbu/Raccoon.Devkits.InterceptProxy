using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy.UnitTest.TestEnvironment
{
    public class IInterceptorSample : IInterceptor
    {
        public void AfterExecute(object target, MethodInfo targetMethod, object?[]? args, object? result)
        {
            Console.WriteLine($"After Execute with target {target.GetType()}: {targetMethod}");
        }

        public void BeforeExecute(object target, MethodInfo targetMethod, object?[]? args)
        {
            Console.WriteLine($"Before Execute with target {target.GetType()}: {targetMethod}");
        }
    }
}
