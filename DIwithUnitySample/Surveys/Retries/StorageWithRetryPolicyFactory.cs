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
using Surveys.Retries;

namespace Surveys.Retries
{
  public abstract class StorageWithRetryPolicyFactory
  {
    private IRetryPolicyFactory retryPolicyFactory;

    protected StorageWithRetryPolicyFactory(IRetryPolicyFactory retryPolicyfactory)
    {
      this.retryPolicyFactory = retryPolicyFactory;
    }

    public IRetryPolicyFactory RetryPolicyFactory
    {
      get
      {
        return retryPolicyFactory;
      }
    }
    public virtual IRetryPolicyFactory GetRetryPolicyFactoryInstance()
    {
      return this.RetryPolicyFactory ?? new DefaultRetryPolicyFactory();
    }
  }
}
