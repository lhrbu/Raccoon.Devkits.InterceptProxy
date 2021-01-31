using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy.UnitTest.TestEnvironment
{
    [Interceptor(typeof(ConstructedGenericInterceptorSample))]
    [Interceptor(typeof(UnConstructedGenericInterceptor<IAsyncServiceSample>))]
    public class AsyncServiceSample : IAsyncServiceSample
    {
        public ValueTask<int> TestAsync()
        {
            Thread.Sleep(200);
            return ValueTask.FromResult(123);
        }
    }
}
