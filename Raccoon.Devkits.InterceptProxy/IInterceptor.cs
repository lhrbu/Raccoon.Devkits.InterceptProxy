using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy
{

    public interface IInterceptor
    {
        void BeforeExecute(object target, MethodInfo targetMethod, object?[]? args);
        void AfterExecute(object target, MethodInfo targetMethod, object?[]? args, object? result);
    }
}
