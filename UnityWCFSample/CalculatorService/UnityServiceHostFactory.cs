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
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using CalculatorEngines;
using Microsoft.Practices.Unity;

namespace CalculatorService
{
  class UnityServiceHostFactory : ServiceHostFactory
  {
    private readonly IUnityContainer container;

    public UnityServiceHostFactory()
    {
      container = new UnityContainer();
      RegisterTypes(container);
    }

    protected override ServiceHost CreateServiceHost(Type serviceType,
        Uri[] baseAddresses)
    {
      return new UnityServiceHost(this.container, serviceType, baseAddresses);
    }

    private void RegisterTypes(IUnityContainer container)
    {
      container.RegisterType<ICalculationEngine, SimpleEngine>();
    }
  }
}
