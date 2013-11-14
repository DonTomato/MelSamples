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
using System.Linq;
using Microsoft.Practices.Unity;
using Surveys;
using Surveys.Stores;
namespace AppIntitializer
{
	class Program
	{
		static void Main(string[] args)
		{
			TextWriterTraceListener tr1 = new TextWriterTraceListener(System.Console.Out);
			Debug.Listeners.Add(tr1);

			using (var container = new UnityContainer())
			{
				Console.WriteLine("# Performing Registrations...");
				ContainerBootstrapper.RegisterTypes(container);
				Console.WriteLine("Container has {0} Registrations:", container.Registrations.Count());

				foreach (ContainerRegistration item in container.Registrations)
				{
					Console.WriteLine(item.GetMappingAsString());
				}

				Console.WriteLine();
				Console.ReadLine();

				Console.WriteLine("# Performing type resolutions...");
				container.Resolve<ISurveyStore>().Initialize();
				//container.Resolve<ISurveyAnswerStore>().Initialize();
				//container.Resolve<ITenantStore>().Initialize();

				Console.WriteLine("Done");
				Console.ReadLine();
			}

		}
	}
}
