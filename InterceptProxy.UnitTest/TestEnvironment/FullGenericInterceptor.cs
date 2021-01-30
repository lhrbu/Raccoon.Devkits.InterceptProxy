using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy.UnitTest.TestEnvironment
{
    public class FullGenericInterceptor<TIService> : Interceptor<TIService>
        where TIService : class
    {
        public override void AfterExecute(TIService service, MethodInfo targetMethod, object?[]? args, object? result)
        {
            Console.WriteLine("Full Generic After");
        }

        public override void BeforeExecute(TIService service, MethodInfo targetMethod, object?[]? args)
        {
            Console.WriteLine("Full Generic Before");
        }
    }
}
