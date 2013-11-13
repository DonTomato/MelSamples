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
using Microsoft.Practices.Unity;
using Surveys.Retries;
using Surveys.DataTables;
using Surveys.MessageQueues;
using Surveys.BlobContainers;
using Surveys.Stores;
using Surveys.Models;
using System.Diagnostics;

namespace Surveys
{
	public class ContainerBootstrapper
	{
		public static void RegisterTypes(IUnityContainer container)
		{
			Trace.WriteLine(string.Format("Called RegisterTypes in ContainerBootstrapper"), "UNITY");

			var storageAccountType = typeof(StorageAccount);
			var retryPolicyFactoryType = typeof(IRetryPolicyFactory);

			// Instance registration
			StorageAccount account = ApplicationConfiguration.GetStorageAccount("DataConnectionString");
			container.RegisterInstance(account);

			// Register factories
			container
				.RegisterInstance<IRetryPolicyFactory>(new ConfiguredRetryPolicyFactory())
				.RegisterType<ISurveyAnswerContainerFactory, SurveyAnswerContainerFactory>(new ContainerControlledLifetimeManager());

			// Register table types
			container
				.RegisterType<IDataTable<SurveyRow>, DataTable<SurveyRow>>(new InjectionConstructor(storageAccountType, retryPolicyFactoryType, Constants.SurveysTableName))
				.RegisterType<IDataTable<QuestionRow>, DataTable<QuestionRow>>(new InjectionConstructor(storageAccountType, retryPolicyFactoryType, Constants.QuestionsTableName));

			// Register message queue type, use typeof with open generics
			container
				.RegisterType(typeof(IMessageQueue<>), typeof(MessageQueue<>), new InjectionConstructor(storageAccountType, retryPolicyFactoryType, typeof(String)));

			// Register blob types
			container
				.RegisterType<IBlobContainer<List<string>>, EntitiesBlobContainer<List<string>>>(new InjectionConstructor(storageAccountType, retryPolicyFactoryType, Constants.SurveyAnswersListsBlobName))
				.RegisterType<IBlobContainer<Tenant>, EntitiesBlobContainer<Tenant>>(new InjectionConstructor(storageAccountType, retryPolicyFactoryType, Constants.TenantsBlobName))
				.RegisterType<IBlobContainer<byte[]>, FilesBlobContainer>(new InjectionConstructor(storageAccountType, retryPolicyFactoryType, Constants.LogosBlobName, "image/jpeg"))
				.RegisterType<IBlobContainer<SurveyAnswer>, EntitiesBlobContainer<SurveyAnswer>>(new InjectionConstructor(storageAccountType, retryPolicyFactoryType, typeof(String)));

			// Register store types
			container
				.RegisterType<ISurveyStore, SurveyStore>()
				.RegisterType<ITenantStore, TenantStore>()
				.RegisterType<ISurveyAnswerStore, SurveyAnswerStore>(new InjectionFactory((c, t, s) => 
					new SurveyAnswerStore(
						container.Resolve<ITenantStore>(), 
						container.Resolve<ISurveyAnswerContainerFactory>(), 
						container.Resolve<IMessageQueue<SurveyAnswerStoredMessage>>(new ParameterOverride("queueName", Constants.StandardAnswerQueueName)),
						container.Resolve<IMessageQueue<SurveyAnswerStoredMessage>>(new ParameterOverride("queueName", Constants.PremiumAnswerQueueName)),
						container.Resolve<IBlobContainer<List<String>>>())));
		}
	}
}
