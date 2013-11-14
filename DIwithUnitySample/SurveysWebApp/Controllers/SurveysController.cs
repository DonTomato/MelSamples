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
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Surveys.Models;
using Surveys.Stores;
using SurveysWebApp.Models;

namespace SurveysWebApp.Controllers
{
	public class SurveysController : Controller
	{
		private readonly ISurveyStore surveyStore;
		private readonly ISurveyAnswerStore surveyAnswerStore;
		private readonly ITenantStore tenantStore;

		public SurveysController(
		  ISurveyStore surveyStore,
		  ISurveyAnswerStore surveyAnswerStore,
		  ITenantStore tenantStore)
		{
			this.surveyStore = surveyStore;
			this.surveyAnswerStore = surveyAnswerStore;
			this.tenantStore = tenantStore;
		}

		public ITenantStore TenantStore
		{
			get { return this.tenantStore; }
		}

		public Tenant Tenant { get; set; }

		[HttpGet]
		public ActionResult Index(string tenant)
		{
			this.Tenant = this.tenantStore.GetTenant(tenant);

			IEnumerable<Survey> surveysForTenant = this.surveyStore.GetSurveysByTenant(tenant);

			var model = this.CreateTenantPageViewData(surveysForTenant);
			model.Title = "My Surveys";

			return this.View(model);
		}

		[HttpGet]
		public ActionResult BrowseResponses(string tenant, string surveySlug, string answerId)
		{
			this.Tenant = this.tenantStore.GetTenant(tenant);

			SurveyAnswer surveyAnswer = null;
			if (string.IsNullOrEmpty(answerId))
			{
				answerId = this.surveyAnswerStore.GetFirstSurveyAnswerId(tenant, surveySlug);
			}

			if (!string.IsNullOrEmpty(answerId))
			{
				surveyAnswer = this.surveyAnswerStore.GetSurveyAnswer(tenant, surveySlug, answerId);
			}

			var surveyAnswerBrowsingContext = this.surveyAnswerStore.GetSurveyAnswerBrowsingContext(tenant, surveySlug, answerId);

			var browseResponsesModel = new BrowseResponseModel
			{
				SurveyAnswer = surveyAnswer,
				PreviousAnswerId = surveyAnswerBrowsingContext.PreviousId,
				ThisAnswerId = surveyAnswerBrowsingContext.ThisId,
				NextAnswerId = surveyAnswerBrowsingContext.NextId
			};

			var model = this.CreateTenantPageViewData(browseResponsesModel);
			model.Title = surveySlug;
			return this.View(model);
		}

		public TenantPageViewData<T> CreateTenantPageViewData<T>(T contentModel)
		{
			var tenantPageViewData = new TenantPageViewData<T>(contentModel)
			{
				Tenant = this.Tenant
			};
			return tenantPageViewData;
		}
	}
}
