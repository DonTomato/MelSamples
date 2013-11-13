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
using System.Text;
using System.Threading.Tasks;

namespace Surveys.Models
{
  public enum SubscriptionKind
  {
    Standard,
    Premium
  }

  [Serializable]
  public class Tenant
  {
    public string ClaimType { get; set; }

    public string ClaimValue { get; set; }

    public string HostGeoLocation { get; set; }

    public string IssuerThumbPrint { get; set; }

    public string IssuerUrl { get; set; }

    public string IssuerIdentifier { get; set; }

    public string Logo { get; set; }

    public string Name { get; set; }

    public string WelcomeText { get; set; }

    public SubscriptionKind SubscriptionKind { get; set; }
  }
}
