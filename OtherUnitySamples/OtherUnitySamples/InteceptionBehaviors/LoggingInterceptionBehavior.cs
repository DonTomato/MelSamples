//===============================================================================
// Microsoft patterns & practices
// Unity Application Block
//===============================================================================
// Copyright © Microsoft Corporation.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
//===============================================================================

using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity.InterceptionExtension;

namespace OtherUnitySamples.InterceptionBehaviors
{


  public class LoggingInterceptionBehavior : IInterceptionBehavior
  {
    public IMethodReturn Invoke(IMethodInvocation input,
      GetNextInterceptionBehaviorDelegate getNext)
    {
      // Before invoking the method on the original target.
      WriteLog(String.Format(
        "Invoking method {0} at {1}",
        input.MethodBase, DateTime.Now.ToLongTimeString()));

      // Invoke the next behavior in the chain.
      var result = getNext()(input, getNext);

      // After invoking the method on the original target.
      if (result.Exception != null)
      {
        WriteLog(String.Format(
          "Method {0} threw exception {1} at {2}",
          input.MethodBase, result.Exception.Message,
          DateTime.Now.ToLongTimeString()));
      }
      else
      {
        WriteLog(String.Format(
          "Method {0} returned {1} at {2}",
          input.MethodBase, result.ReturnValue,
          DateTime.Now.ToLongTimeString()));
      }

      return result;
    }

    public IEnumerable<Type> GetRequiredInterfaces()
    {
      return Type.EmptyTypes;
    }

    public bool WillExecute
    {
      get { return true; }
    }

    private void WriteLog(string message)
    {
      Console.WriteLine("From the logging interceptor: {0}", message);
    }
  }

}
