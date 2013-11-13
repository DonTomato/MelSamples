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
using System.Diagnostics;
using System.Globalization;
using Surveys.BlobContainers;
using Surveys.MessageQueues;
using Surveys.Models;

namespace Surveys.Stores
{
	class SurveyAnswerStore : ISurveyAnswerStore
	{
		private readonly ITenantStore tenantStore;
		private readonly ISurveyAnswerContainerFactory surveyAnswerContainerFactory;
		private readonly IMessageQueue<SurveyAnswerStoredMessage> standardSurveyAnswerStoredQueue;
		private readonly IMessageQueue<SurveyAnswerStoredMessage> premiumSurveyAnswerStoredQueue;
		private readonly IBlobContainer<List<string>> surveyAnswerIdsListContainer;

		public SurveyAnswerStore(
			ITenantStore tenantStore,
			ISurveyAnswerContainerFactory surveyAnswerContainerFactory,
			IMessageQueue<SurveyAnswerStoredMessage> standardSurveyAnswerStoredQueue,
			IMessageQueue<SurveyAnswerStoredMessage> premiumSurveyAnswerStoredQueue,
			IBlobContainer<List<string>> surveyAnswerIdsListContainer)
		{
			Trace.WriteLine(string.Format("Called constructor in SurveyAnswerStore"), "UNITY");
			this.tenantStore = tenantStore;
			this.surveyAnswerContainerFactory = surveyAnswerContainerFactory;
			this.standardSurveyAnswerStoredQueue = standardSurveyAnswerStoredQueue;
			this.premiumSurveyAnswerStoredQueue = premiumSurveyAnswerStoredQueue;
			this.surveyAnswerIdsListContainer = surveyAnswerIdsListContainer;
		}

		public void Initialize()
		{
			Trace.WriteLine(string.Format("Called Initialize in SurveyAnswerStore"), "UNITY");
			this.surveyAnswerIdsListContainer.EnsureExist();
			this.premiumSurveyAnswerStoredQueue.EnsureExist();
			this.standardSurveyAnswerStoredQueue.EnsureExist();
		}

		public void SaveSurveyAnswer(SurveyAnswer surveyAnswer)
		{
			throw new NotImplementedException();
		}

		public SurveyAnswer GetSurveyAnswer(string tenant, string slugName, string surveyAnswerId)
		{
			var surveyBlobContainer = this.surveyAnswerContainerFactory.Create(tenant, slugName);
			surveyBlobContainer.EnsureExist();
			return surveyBlobContainer.Get(surveyAnswerId);
		}

		public string GetFirstSurveyAnswerId(string tenant, string slugName)
		{
			string id = string.Format(CultureInfo.InvariantCulture, "{0}-{1}", tenant, slugName);
			var answerIdList = this.surveyAnswerIdsListContainer.Get(id);

			if (answerIdList != null)
			{
				return answerIdList[0];
			}

			return string.Empty;
		}

		public void AppendSurveyAnswerIdsToAnswersList(string tenant, string slugName, IEnumerable<string> surveyAnswerIds)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<string> GetSurveyAnswerIds(string tenant, string slugName)
		{
			throw new NotImplementedException();
		}

		public void DeleteSurveyAnswers(string tenant, string slugName)
		{
			throw new NotImplementedException();
		}


		public SurveyAnswerBrowsingContext GetSurveyAnswerBrowsingContext(string tenant, string slugName, string answerId)
		{
			string id = string.Format(CultureInfo.InvariantCulture, "{0}-{1}", tenant, slugName);
			var answerIdsList = this.surveyAnswerIdsListContainer.Get(id);

			string previousId = null;
			string nextId = null;
			string thisId = null;
			if (answerIdsList != null)
			{
				var currentAnswerIndex = answerIdsList.FindIndex(i => i == answerId);
				thisId = (currentAnswerIndex + 1).ToString();
				if (currentAnswerIndex - 1 >= 0)
				{
					previousId = answerIdsList[currentAnswerIndex - 1];
				}

				if (currentAnswerIndex + 1 <= answerIdsList.Count - 1)
				{
					nextId = answerIdsList[currentAnswerIndex + 1];
				}
			}

			return new SurveyAnswerBrowsingContext
			{
				PreviousId = previousId,
				ThisId = thisId,
				NextId = nextId
			};
		}
	}
}
