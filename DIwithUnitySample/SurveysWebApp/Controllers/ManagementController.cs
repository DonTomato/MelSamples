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
using System.Web;
using System.Web.Mvc;
using Surveys.Stores;
using Surveys.Models;
using SurveysWebApp.Models;

namespace SurveysWebApp.Controllers
{
	public class ManagementController : Controller
	{
		private readonly ITenantStore tenantStore;

		public ManagementController(ITenantStore tenantStore)
		{
			this.tenantStore = tenantStore;
		}

		public ActionResult Index()
		{
			var model = new TenantPageViewData<IEnumerable<string>>(this.tenantStore.GetTenantNames())
			{
				Title = "Subscribers"
			};
			return this.View(model);
		}

		public ActionResult Detail(string tenant)
		{
			var contentModel = this.tenantStore.GetTenant(tenant);
			var model = new TenantPageViewData<Tenant>(contentModel)
			{
				Title = string.Format("{0} details", contentModel.Name)
			};
			return this.View(model);
		}
	}
}
