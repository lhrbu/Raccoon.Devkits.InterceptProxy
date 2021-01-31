using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy.UnitTest.TestEnvironment
{
    [Interceptor(typeof(InterfaceInterceptorSample))]
    public interface IAsyncServiceSample
    {
        ValueTask<int> TestAsync();
    }
}
