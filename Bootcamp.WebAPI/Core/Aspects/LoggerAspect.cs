﻿using System.Diagnostics;
using Bootcamp.WebAPI.Core.Utilities.Interceptor;
using Castle.DynamicProxy;

namespace Bootcamp.WebAPI.Core.Aspects
{
    public class LoggerAspect : MethodInterception
    {
        protected override void OnBefore(IInvocation invocation)
        {
           Debug.WriteLine("OnBefore Logger Aspect");
        }

        protected override void OnAfter(IInvocation invocation)
        {
            Debug.WriteLine("OnAfter Logger Aspect");
        }
    }
}