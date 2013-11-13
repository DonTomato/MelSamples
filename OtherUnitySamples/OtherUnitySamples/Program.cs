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
using System.IO;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Configuration;

using DevGuideExample.MenuSystem;

// references to application block namespace(s) for these examples
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection;
using Microsoft.Practices.EnterpriseLibrary.PolicyInjection.Configuration;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.InterceptionExtension;

using OtherUnitySamples.InterceptionBehaviors;
using OtherUnitySamples.Conventions;


namespace OtherUnitySamples
{
  class Program
  {

    static void Main(string[] args)
    {
      #region Create the required objects

      #endregion

      new MenuDrivenApplication("Unity Developer's Guide Other Examples",
          SimpleLazyExample,
          LazyWithSingletons,
          RegistrationByConvention,
          RegistrationByConventionGenerics,
          RegistrationByConventionWithLifetime,
          RegistrationByConventionPlusFilter,
          RegistrationByConventionPlusManualChange,
          RegistrationByConventionWithInterception,
          UsingARegistrationConvention, DuplicateRegistrations).Run();
    }

    [Description("Basic use of Lazy<T> with Unity")]
    static void SimpleLazyExample()
    {
      using (var container = new UnityContainer())
      {
        Console.WriteLine("Registing the MySampleObject Type\n");
        // Register the type
        container.RegisterType<MySampleObject>(new InjectionConstructor("default"));

        Console.WriteLine("Resolve Lazy<MySampleObject> from the container");
        Console.WriteLine("Note that the constructor of MySampleObject is not invoked\n");
        // Resolve using Lazy<T>
        var defaultLazy = container.Resolve<Lazy<MySampleObject>>();

        Console.WriteLine("Perform the lazy initialiazation");
        // Use the resolved object
        var mySampleObject = defaultLazy.Value;
      }
     }

    [Description("Using Lazy<T> with ContainerManagedLifetime")]
    static void LazyWithSingletons()
    {
      using (var container = new UnityContainer())
      {
        Console.WriteLine("Create a named Registration for the MySampleObject Type");
        Console.WriteLine("Using the ContainerControlledLifetimeManager\n");

        // Register the type with a lifetime manager
        container.RegisterType<MySampleObject>("other", new ContainerControlledLifetimeManager(), new InjectionConstructor("other"));

        Console.WriteLine("Resolve Lazy<MySampleObject> from the container");
        // Resolve the lazy type
        var defaultLazy1 = container.Resolve<Lazy<MySampleObject>>("other");

        Console.WriteLine("Resolve Lazy<MySampleObject> from the container a second time\n");
        // Resolve the lazy type a second time
        var defaultLazy2 = container.Resolve<Lazy<MySampleObject>>("other");

        // defaultLazy1 == defaultLazy2 is false
        // defaultLazy1.Value == defaultLazy2.Value is true
        Console.WriteLine("Is the Lazy<MySampleObject> instance a singleton: {0}", defaultLazy1 == defaultLazy2);
        Console.WriteLine("Is the MySampleObject instance a singleton: {0}", defaultLazy1.Value == defaultLazy2.Value);

      }
    }

    [Description("Simple example of using registration by convention")]
    static void RegistrationByConvention()
    {
      using (var container = new UnityContainer())
      {
        container.RegisterTypes(
          AllClasses.FromLoadedAssemblies(),
          WithMappings.FromMatchingInterface,
          WithName.Default);

        DisplayRegistrations(container);
      }
    }

    [Description("Simple example of using registration by convention using an open generic")]
    static void RegistrationByConventionGenerics()
    {
      using (var container = new UnityContainer())
      {
        container.RegisterTypes(
          // Registers open generics
          AllClasses.FromLoadedAssemblies(),
          WithMappings.FromMatchingInterface,
          WithName.Default);

        // Add a registration of a closed generic
        container.RegisterType<ICustomerStore<TableStorage>, CustomerStore<TableStorage>>();
        DisplayRegistrations(container);

        // Uses the registration of the open generic type
        var blobCustomerStore = container.Resolve<ICustomerStore<BlobStorage>>();

        // Uses the registration of the closed generic type
        var tableCustomerStore = container.Resolve<ICustomerStore<TableStorage>>();
      }
    }

    [Description("Using registration by convention with a lifetime manager and a name")]
    static void RegistrationByConventionWithLifetime()
    {
      using (var container = new UnityContainer())
      {
        container.RegisterTypes(
          AllClasses.FromLoadedAssemblies(),
          WithMappings.FromMatchingInterface,
          WithName.TypeName,
          WithLifetime.ContainerControlled);

        DisplayRegistrations(container);
      }
    }

    [Description("Using registration by convention and then tweak")]
    static void RegistrationByConventionPlusManualChange()
    {
      using (var container = new UnityContainer())
      {
        container.RegisterTypes(
          AllClasses.FromLoadedAssemblies(),
          WithMappings.FromMatchingInterface,
          WithName.Default,
          WithLifetime.ContainerControlled);

        // Provide some additional information for this registration
        container.RegisterType<TenantStore>(new InjectionConstructor("Adatum"));

        var tenantStore = container.Resolve<ITenantStore>();
      }
    }

    [Description("Using registration by convention and filtering the types")]
    static void RegistrationByConventionPlusFilter()
    {
      using (var container = new UnityContainer())
      {
        container.RegisterTypes(
          AllClasses.FromLoadedAssemblies().Where(t => t.Namespace == "OtherUnitySamples"),
          WithMappings.FromMatchingInterface,
          WithName.Default,
          WithLifetime.ContainerControlled);

        DisplayRegistrations(container);
      }
    }

    [Description("Using registration by convention with interception")]
    static void RegistrationByConventionWithInterception()
    {
      using (var container = new UnityContainer())
      {
        container.AddNewExtension<Interception>();
        container.RegisterTypes(
          AllClasses.FromLoadedAssemblies().Where(t => t.Namespace == "OtherUnitySamples"),
          WithMappings.FromMatchingInterface,
          getInjectionMembers: t => new InjectionMember[] { new Interceptor<VirtualMethodInterceptor>(), new InterceptionBehavior<LoggingInterceptionBehavior>() });
          

        container.RegisterType<TenantStore>(new InjectionConstructor("Adatum"));
        container.RegisterType<SurveyStore>(new InjectionConstructor("Adatum"));

        var tenantStore = container.Resolve<ITenantStore>();
        tenantStore.Save();
        var surveyStore = container.Resolve<ISurveyStore>();
        surveyStore.Save();
      }
    }

    [Description("Using a Registration Convention")]
    static void UsingARegistrationConvention()
    {
      using (var container = new UnityContainer())
      {
        container.RegisterTypes(new SampleConvention());

        DisplayRegistrations(container);
      }
    }

    [Description("Duplicate Registrations in Registration by Convention")]
    static void DuplicateRegistrations()
    {
      using (var container = new UnityContainer())
      {
        container.RegisterTypes(
          new[] { typeof(TenantStore), typeof(TenantStore2) },
          t => new[] { typeof(ITenantStore) },
          overwriteExistingMappings: true);

        DisplayRegistrations(container);

      }
    }

    #region Auxiliary routines
    static void DisplayRegistrations(UnityContainer container)
    {
      Console.WriteLine("Container has {0} Registrations:", container.Registrations.Count());
      foreach (ContainerRegistration item in container.Registrations)
      {
        Console.WriteLine(item.GetMappingAsString());
      }

    }

    #endregion
  }
  
  public class MySampleObject
  {
    public MySampleObject(string name)
    {
      Console.WriteLine("Creating MySampleObject " + name);
    }
  }

  public interface ITenantStore
  {
    void Save();
  }

  public class TenantStore : ITenantStore
  {
    public TenantStore(string tenantName)
    {
      Console.WriteLine("Creating TenantStore for " + tenantName);
    }
    public virtual void Save() { }
  }

  public class TenantStore2 : ITenantStore
  {
    public TenantStore2(string tenantName)
    {
      Console.WriteLine("Creating TenantStore2 for " + tenantName);
    }
    public virtual void Save() { }
  }

  public interface ISurveyStore
  {
    void Save();
  }

  public class SurveyStore : ISurveyStore
  {
    public SurveyStore(string surveyName)
    {
      Console.WriteLine("Creating SurveyStore for " + surveyName);
    }
    public virtual void Save() { }
  }

  public interface ICustomerStore<T>
  {
    void Save();
  }

  public class CustomerStore<T> : ICustomerStore<T>
  {
    public CustomerStore()
    {
      Console.WriteLine("Creating CustomerStore for Type:{0}", typeof(T));
    }
    public virtual void Save() { }
  }

  public class BlobStorage { };
  public class TableStorage { };


  static class ContainerRegistrationsExtension
  {
    public static string GetMappingAsString(
      this ContainerRegistration registration)
    {
      string regName, regType, mapTo, lifetime;

      var r = registration.RegisteredType;
      regType = r.Name + GetGenericArgumentsList(r);

      var m = registration.MappedToType;
      mapTo = m.Name + GetGenericArgumentsList(m);

      regName = registration.Name ?? "[default]";

      lifetime = registration.LifetimeManagerType.Name;
      if (mapTo != regType)
      {
        mapTo = " -> " + mapTo;
      }
      else
      {
        mapTo = string.Empty;
      }
      lifetime = lifetime.Substring(
        0, lifetime.Length - "LifetimeManager".Length);
      return String.Format(
        "+ {0}{1}  '{2}'  {3}", regType, mapTo, regName, lifetime);
    }

    private static string GetGenericArgumentsList(Type type)
    {
      if (type.GetGenericArguments().Length == 0) return string.Empty;
      string arglist = string.Empty;
      bool first = true;
      foreach (Type t in type.GetGenericArguments())
      {
        arglist += first ? t.Name : ", " + t.Name;
        first = false;
        if (t.GetGenericArguments().Length > 0)
        {
          arglist += GetGenericArgumentsList(t);
        }
      }
      return "<" + arglist + ">";
    }
  }

}
