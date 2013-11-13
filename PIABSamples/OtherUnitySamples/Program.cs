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
using System.Diagnostics;
using System.ComponentModel;

using DevGuideExample.MenuSystem;

// references to application block namespace(s) for these examples
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;
using Microsoft.Practices.EnterpriseLibrary.Logging.PolicyInjection;

namespace OtherUnitySamples
{
  class Program
  {

    static void Main(string[] args)
    {
      #region Create the required objects

      #endregion

      new MenuDrivenApplication("Unity Developer's PIAB Examples",
          UsingPIABWithContainer,
          UsingPIABWithFacade).Run();
    }


    [Description("Using the Policy Injection Application Block with a container")]
    static void UsingPIABWithContainer()
    {
      ConfigureLogger();
      using (var container = new UnityContainer())
      {

        container.AddNewExtension<Interception>();
        container.RegisterType<InterceptableTenantStore>(new Interceptor<TransparentProxyInterceptor>(), new InterceptionBehavior<PolicyInjectionBehavior>());

        container.Configure<Interception>().AddPolicy("logging")
             .AddMatchingRule<MemberNameMatchingRule>(
                new InjectionConstructor(
                new InjectionParameter("Save")))
             .AddCallHandler<LogCallHandler>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(
                  9001, true, false,
                  "This is before the method call",
                  "This is after the method call", false, false, true, 10, 1));


        var tenantStore = container.Resolve<InterceptableTenantStore>();

        // Use the interceptable type.
        Console.WriteLine("*** Invoking the Save method ***");
        tenantStore.Save();
        Console.WriteLine("*** Invoking the Modify method ***");
        tenantStore.Modify();
      }
    }

    [Description("Using the Policy Injection Application Block static facade")]
    static void UsingPIABWithFacade()
    {
      // Configure the logger first.
      ConfigureLogger();

      // Bootstrap the Policy Injection Application Block
      // and configure the interceptable type.
      // This example loads the configuration from the config file.
      PolicyInjection.SetPolicyInjector(new PolicyInjector(new SystemConfigurationSource(false)), false);
      var tenantStore = PolicyInjection.Create<InterceptableTenantStore>();

      // Use the interceptable type
      Console.WriteLine("*** Invoking the Save method ***");
      tenantStore.Save();
      Console.WriteLine("*** Invoking the Modify method ***");
      tenantStore.Modify();



    }

    #region Auxiliary routines
    private static void ConfigureLogger()
    {
      var configuration = new LoggingConfiguration();
      configuration.AddLogSource("default", new ConsoleTraceListener());
      configuration.DefaultSource = "default";
      var logWriter = new LogWriter(configuration);
      Logger.SetLogWriter(logWriter, false);
    }

    #endregion
  }
  

  public class InterceptableTenantStore : MarshalByRefObject
  {
    public void Save() { }
    public void Modify() { }
  }

}
