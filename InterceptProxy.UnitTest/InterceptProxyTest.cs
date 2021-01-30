using Microsoft.Extensions.DependencyInjection;
using Raccoon.Devkits.InterceptProxy.UnitTest.TestEnvironment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Raccoon.Devkits.InterceptProxy.UnitTest
{
    public class InterceptProxyTest
    {
        private readonly IServiceProvider _serviceProvider;
        public InterceptProxyTest()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<IInterceptorSample>();
            services.AddTransient<AbstractInterceptorSample>();
            services.AddTransient<FullGenericInterceptor<IServiceSample>>();
            services.AddTransientProxy<IServiceSample, ServiceSample>(
                typeof(IInterceptorSample),
                typeof(AbstractInterceptorSample),
                typeof(FullGenericInterceptor<IServiceSample>));
            _serviceProvider = services.BuildServiceProvider();
        }

        [Fact]
        public void SyncInvokeTest()
        {
            IServiceSample serviceSample = _serviceProvider.GetRequiredService<IServiceSample>();
            Type type = serviceSample.GetType();
            serviceSample.VoidMethod();
            int value = serviceSample.FuncMethod();
            Assert.Equal(serviceSample.ValueProperty, value);
        }
    }
}
