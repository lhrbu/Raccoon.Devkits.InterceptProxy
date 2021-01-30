using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raccoon.Devkits.InterceptProxy
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Interface,AllowMultiple =true)]
    public class InterceptorAttribute:Attribute
    {
        public Type InterceptorType { get; }
        public InterceptorAttribute(Type interceptorType)
        {
            if(typeof(IInterceptor).IsAssignableFrom(interceptorType))
            { InterceptorType = interceptorType; }
            else { throw new ArgumentException(
                $"{interceptorType} is not a implementation of interface {nameof(IInterceptor)}",nameof(interceptorType));
            }
        }
    }
}
