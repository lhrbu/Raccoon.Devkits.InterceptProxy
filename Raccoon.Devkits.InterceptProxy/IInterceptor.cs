using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy
{
    public interface IInterceptor
    {
        object? OnExecuting(object target, MethodInfo targetMethod, object?[]? args,
            Func<object?> next);
    }
}
