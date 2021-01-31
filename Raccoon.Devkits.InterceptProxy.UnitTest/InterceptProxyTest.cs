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
            services.AddTransient<InterfaceInterceptorSample>();
            services.AddTransient<ConstructedGenericInterceptorSample>();
            services.AddTransient<UnConstructedGenericInterceptor<IServiceSample>>();
            services.AddTransientProxy<IServiceSample, ServiceSample>(
                typeof(InterfaceInterceptorSample),
                typeof(ConstructedGenericInterceptorSample),
                typeof(UnConstructedGenericInterceptor<IServiceSample>));

            services.AddTransient<UnConstructedGenericInterceptor<IAsyncServiceSample>>();
            services.AddTransientProxy<IAsyncServiceSample, AsyncServiceSample>();

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

        [Fact]
        public async Task AsyncInvokeTest()
        {
            try
            {
                IAsyncServiceSample serviceSample = _serviceProvider.GetRequiredService<IAsyncServiceSample>();
                Type type = serviceSample.GetType();
                int ret = await serviceSample.TestAsync().ConfigureAwait(true);
            }catch(ArgumentException exp)
            {
                Assert.Equal("target", exp.ParamName);
            }
        }
    }
}
