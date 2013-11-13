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
using Microsoft.Practices.Unity;

namespace CustomLifetimeManagers
{
  class Program
  {
    static void Main(string[] args)
    {
      IUnityContainer container = new UnityContainer();
      var cache = new SimpleMemoryCache();
      container.RegisterType<Tenant>(new CachedLifetimeManager(cache));
      var tenant = container.Resolve<Tenant>();
      var tenant2 = container.Resolve<Tenant>();

      Console.ReadLine();
    }
  }
}
