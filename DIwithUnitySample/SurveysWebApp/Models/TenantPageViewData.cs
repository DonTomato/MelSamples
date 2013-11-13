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
using Surveys.Models;

namespace SurveysWebApp.Models
{
  public class TenantPageViewData<T> : TenantMasterPageViewData
  {
    private readonly T contentModel;

    public TenantPageViewData(T contentModel)
    {
      this.contentModel = contentModel;
    }

    public T ContentModel
    {
      get
      {
        return this.contentModel;
      }
    }
  }
}
