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
using Surveys.Retries;

namespace Surveys.BlobContainers
{
  class EntitiesBlobContainer<T> : StorageWithRetryPolicyFactory, IBlobContainer<T>
  {
    private readonly string Container;
    private readonly StorageAccount Account;

    public EntitiesBlobContainer(StorageAccount account, IRetryPolicyFactory retryPolicyFactory)
      : this(account, retryPolicyFactory, typeof(T).Name.ToLowerInvariant()) { }

    public EntitiesBlobContainer(StorageAccount account, IRetryPolicyFactory retryPolicyFactory, string blobContainerName) : base(retryPolicyFactory)
    {
      Trace.WriteLine(string.Format("Called constructor in EntitiesBlobContainer with account={0}, blobContainerName={1}", account.ConnectionString, blobContainerName),"UNITY");
      this.Account = account;
      this.Container = blobContainerName;
    }

    public void EnsureExist()
    {
      Trace.WriteLine(string.Format("Checking EntitiesBlobContainer {0} exists", Container), "UNITY");
    }

    public T Get(string objId)
    {
      var blobcontent = DummyBlobReader<T>.GetBlob(objId);
      if (blobcontent != null)
      {
        return (T)blobcontent;
      }
      return default(T);
    }

    public IEnumerable<IListBlobItemWithName> GetBlobList()
    {
      return DummyBlobReader<T>.ListBlobs();
    }

    public Uri GetUri(string objId)
    {
      throw new NotImplementedException();
    }

    public void Delete(string objId)
    {
      throw new NotImplementedException();
    }

    public void DeleteContainer()
    {
      throw new NotImplementedException();
    }

    public void Save(string objId, T obj)
    {
      throw new NotImplementedException();
    }

    public void Save(T obj)
    {
      throw new NotImplementedException();
    }
  }
}
