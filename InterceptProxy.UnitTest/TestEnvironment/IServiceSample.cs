using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy.UnitTest.TestEnvironment
{
    public interface IServiceSample
    {
        int ValueProperty { get; set; }
        void VoidMethod();
        int FuncMethod();
    }
}
