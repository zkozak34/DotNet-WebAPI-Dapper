using Bootcamp.WebAPI.Core.Utilities.Interceptor;
using Castle.DynamicProxy;

namespace Bootcamp.WebAPI.Core.Aspects
{
    public class LoggerAspect : MethodInterception
    {
        protected override void OnBefore(IInvocation invocation)
        {
           Console.WriteLine($"OnBefore Logger Aspect.");
        }

        protected override void OnAfter(IInvocation invocation)
        {
            Console.WriteLine("OnAfter Logger Aspect.");
        }
    }
}
