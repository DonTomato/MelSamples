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

using System.Collections.Generic;
using Surveys.Models;

namespace Surveys.Stores
{
  public interface ITenantStore
  {
    void Initialize();
    Tenant GetTenant(string tenant);
    IEnumerable<string> GetTenantNames();
    void SaveTenant(Tenant tenant);
    void UploadLogo(string tenant, byte[] logo);
  }
}
