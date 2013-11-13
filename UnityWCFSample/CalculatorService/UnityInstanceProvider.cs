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
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Threading.Tasks;
using CalculatorEngines;
using Microsoft.Practices.Unity;

namespace CalculatorService
{
  public class UnityInstanceProvider : IInstanceProvider, IContractBehavior
  {
    private readonly IUnityContainer container;

    public UnityInstanceProvider(IUnityContainer container)
    {
      if (container == null)
      {
        throw new ArgumentNullException("container");
      }

      this.container = container;
    }

    #region IInstanceProvider Members

    public object GetInstance(InstanceContext instanceContext, Message message)
    {
      return this.GetInstance(instanceContext);
    }

    public object GetInstance(InstanceContext instanceContext)
    {
      return this.container.Resolve(instanceContext.Host.Description.ServiceType);
    }

    public void ReleaseInstance(InstanceContext instanceContext, object instance)
    {
    }

    #endregion

    #region IContractBehavior Members

    public void AddBindingParameters(ContractDescription contractDescription, ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
    {
    }

    public void ApplyClientBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
    }

    public void ApplyDispatchBehavior(ContractDescription contractDescription, ServiceEndpoint endpoint, DispatchRuntime dispatchRuntime)
    {
      dispatchRuntime.InstanceProvider = this;
    }

    public void Validate(ContractDescription contractDescription, ServiceEndpoint endpoint)
    {
    }

    #endregion
  }
}
