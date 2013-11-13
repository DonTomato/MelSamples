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
using System.Reflection;
using Microsoft.Practices.Unity;

namespace OtherUnitySamples.Conventions
{
  class SampleConvention : RegistrationConvention
  {
    public override Func<Type, IEnumerable<Type>> GetFromTypes()
    {
      return t => t.GetTypeInfo().ImplementedInterfaces;
    }

    public override Func<Type, IEnumerable<InjectionMember>> GetInjectionMembers()
    {
      return null;
    }

    public override Func<Type, LifetimeManager> GetLifetimeManager()
    {
      return t => new ContainerControlledLifetimeManager();
    }

    public override Func<Type, string> GetName()
    {
      return t => t.Name;
    }

    public override IEnumerable<Type> GetTypes()
    {
      yield return typeof(TenantStore);
      yield return typeof(SurveyStore);
    }
  }
}
