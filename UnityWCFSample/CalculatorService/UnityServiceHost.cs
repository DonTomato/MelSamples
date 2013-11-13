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
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using CalculatorEngines;
using Microsoft.Practices.Unity;

namespace CalculatorService
{
  public class UnityServiceHost : ServiceHost
  {
    public UnityServiceHost(IUnityContainer container, Type serviceType, params Uri[] baseAddresses)
      : base(serviceType, baseAddresses)
    {
      if (container == null)
      {
        throw new ArgumentNullException("container");
      }

      foreach (var cd in this.ImplementedContracts.Values)
      {
        cd.Behaviors.Add(new UnityInstanceProvider(container));
      }
    }
  }
}
