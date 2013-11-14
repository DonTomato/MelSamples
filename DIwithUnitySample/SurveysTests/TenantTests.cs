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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Surveys.BlobContainers;
using Surveys.Models;
using Surveys.Stores;

namespace SurveysTests
{
	[TestClass]
	public class TenantTests
	{
		[TestMethod]
		public void GetTenantReturnsTenantFromBlobStorage()
		{
			var mockTenantBlobContainer = new Mock<IBlobContainer<Tenant>>();
			var store = new TenantStore(mockTenantBlobContainer.Object, null);
			var tenant = new Tenant();
			mockTenantBlobContainer.Setup(c => c.Get("tenant")).Returns(tenant);

			var actualTenant = store.GetTenant("tenant");

			Assert.AreSame(tenant, actualTenant);
		}
	}
}
