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
using System.ServiceModel.Description;
using System.Text;
using System.Threading.Tasks;
using CalculatorEngines;
using CalculatorService;
using Microsoft.Practices.Unity;

namespace CalculatorServiceHost
{
  class Program
  {
    static void Main(string[] args)
    {
      // Register types with Unity
      using (IUnityContainer container = new UnityContainer())
      {
        RegisterTypes(container);

        // Step 1 Create a URI to serve as the base address.
        Uri baseAddress = new Uri("http://localhost:8000/GettingStarted/");

        // Step 2 Create a ServiceHost instance
        ServiceHost selfHost = new UnityServiceHost(container, typeof(CalculatorService.CalculatorService), baseAddress);


        try
        {
          // Step 3 Add a service endpoint.
          selfHost.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "CalculatorService");

          // Step 4 Enable metadata exchange.
          ServiceMetadataBehavior smb = new ServiceMetadataBehavior();
          smb.HttpGetEnabled = true;
          selfHost.Description.Behaviors.Add(smb);

          // Step 5 Start the service.
          selfHost.Open();
          Console.WriteLine("The service is ready.");
          Console.WriteLine("Press <ENTER> to terminate service.");
          Console.WriteLine();
          Console.ReadLine();

          // Close the ServiceHostBase to shutdown the service.
          selfHost.Close();
        }
        catch (CommunicationException ce)
        {
          Console.WriteLine("An exception occurred: {0}", ce.Message);
          selfHost.Abort();
        }
      }
    }

    private static void RegisterTypes(IUnityContainer container)
    {
      container.RegisterType<ICalculationEngine, SimpleEngine>();
    }
  }
}
