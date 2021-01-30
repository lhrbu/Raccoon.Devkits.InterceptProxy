using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy.UnitTest.TestEnvironment
{
    public class AbstractInterceptorSample : Interceptor<IServiceSample>
    {
        public override void AfterExecute(IServiceSample service, MethodInfo targetMethod, object?[]? args, object? result)
        {
            Console.WriteLine("Abstract After");
        }

        public override void BeforeExecute(IServiceSample service, MethodInfo targetMethod, object?[]? args)
        {
            Console.WriteLine("Abstract Before!");
        }
    }
}
