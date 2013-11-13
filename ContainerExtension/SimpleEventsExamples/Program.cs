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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventBrokerExtension;
using Microsoft.Practices.Unity;
using SimpleEventBroker;

namespace SimpleEventsExamples
{
  class Program
  {
    static void Main(string[] args)
    {
      Example1();
      Example2();
      Example3();

      Console.WriteLine("\nPress Enter to close this window.");
      Console.ReadLine();

    }

    static void Example1()
    {
      Console.WriteLine("\nExample #1 using named registrations\n");
      using (IUnityContainer container = new UnityContainer())
      {
        container
          .RegisterType<Publisher>(new ContainerControlledLifetimeManager())
          .RegisterType<Subscriber>(new InjectionConstructor("default", typeof(Publisher)));

        var pub = container.Resolve<Publisher>();
        var sub1 = container.Resolve<Subscriber>(new ParameterOverride("ID", "1sub1"));
        var sub2 = container.Resolve<Subscriber>(new ParameterOverride("ID", "1sub2"));

        // Call the method that raises the event.
        pub.DoSomething();
      }
    }

    static void Example2()
    {
      Console.WriteLine("\nExample #2 using instance registrations\n");
      using (IUnityContainer container = new UnityContainer())
      {
        container
          .RegisterType<Publisher>(new ContainerControlledLifetimeManager())
          .RegisterInstance<Subscriber>(new Subscriber("2sub1", container.Resolve<Publisher>()))
          .RegisterInstance<Subscriber>(new Subscriber("2sub2", container.Resolve<Publisher>()));

        var pub = container.Resolve<Publisher>();

        // Call the method that raises the event.
        pub.DoSomething();
      }
    }

    static void Example3()
    {
      Console.WriteLine("\nExample #3 using EventBrokerExtension\n");
      using (IUnityContainer container = new UnityContainer())
      {
        container
          .AddNewExtension<SimpleEventBrokerExtension>()
          .RegisterType<Publisher>()
          .RegisterType<Subscriber>(new InjectionConstructor("default"));

        var pub = container.Resolve<Publisher>();
        var sub1 = container.Resolve<Subscriber>(new ParameterOverride("ID", "3sub1"));
        var sub2 = container.Resolve<Subscriber>(new ParameterOverride("ID", "3sub2"));

        // Call the method that raises the event.
        pub.DoSomething();
      }
    }
  }
}
