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
using Surveys.BlobContainers;
using Surveys.Models;
using System.Linq;

namespace Surveys.Stores
{
  public class TenantStore : ITenantStore
  {
    private readonly IBlobContainer<Tenant> tenantBlobContainer;
    private readonly IBlobContainer<byte[]> logosBlobContainer;

    public TenantStore(IBlobContainer<Tenant> tenantBlobContainer, IBlobContainer<byte[]> logosBlobContainer)
    {
      Trace.WriteLine(string.Format("Called constructor in TenantStore"), "UNITY");

      this.tenantBlobContainer = tenantBlobContainer;
      this.logosBlobContainer = logosBlobContainer;
     }

    public void Initialize()
    {
      Trace.WriteLine(string.Format("Called Initialize in TenantStore"), "UNITY");

      this.logosBlobContainer.EnsureExist();

      this.tenantBlobContainer.EnsureExist();

      Console.WriteLine("Initialized a TenantStore instance");
    }

    public Tenant GetTenant(string tenant)
    {
      return tenantBlobContainer.Get(tenant);
    }

    public IEnumerable<string> GetTenantNames()
    {
      return this.tenantBlobContainer.GetBlobList().Select(b => b.Name);
    }

    public void SaveTenant(Tenant tenant)
    {
      throw new NotImplementedException();
    }

    public void UploadLogo(string tenant, byte[] logo)
    {
      throw new NotImplementedException();
    }
  }
}
