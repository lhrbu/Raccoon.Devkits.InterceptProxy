using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy.UnitTest.TestEnvironment
{
    public class ServiceSample : IServiceSample
    {
        public int ValueProperty { get; set; } = 25;

        public int FuncMethod()
        {
            Console.WriteLine($"ValuePropery is {ValueProperty}");
            return ValueProperty;
        }

        public void VoidMethod()
        {
            Console.WriteLine("Hello Proxy!");
        }
    }
}
