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
  class FilesBlobContainer : StorageWithRetryPolicyFactory, IBlobContainer<byte[]>
  {
    private readonly string contentType;
    private readonly string Container;
    private readonly StorageAccount Account;

    public FilesBlobContainer(StorageAccount account, IRetryPolicyFactory retryPolicyFactory, string containerName, string contentType) : base(retryPolicyFactory)
    {
      Trace.WriteLine(string.Format("Called constructor in FilesBlobContainer with account={0}, blobContainerName={1}, contentType={2}", account.ConnectionString, containerName, contentType), "UNITY");
      this.Account = account;
      this.Container = containerName;
      this.contentType = contentType;
    }

    public void EnsureExist()
    {
      Trace.WriteLine(string.Format("Checking FileBlobContainer {0} exists", Container), "UNITY");
    }

    public byte[] Get(string objId)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<IListBlobItemWithName> GetBlobList()
    {
      throw new NotImplementedException();
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

    public void Save(string objId, byte[] obj)
    {
      throw new NotImplementedException();
    }


    public void Save(byte[] obj)
    {
      throw new NotImplementedException();
    }
  }
}
