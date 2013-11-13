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
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Practices.ObjectBuilder2;
using Microsoft.Practices.Unity;

namespace CustomLifetimeManagers
{
  public class CachedLifetimeManager : SynchronizedLifetimeManager, IDisposable
  {
    private IStorage storage;
    private string key;

    public CachedLifetimeManager(IStorage storage)
    {
      this.storage = storage;
      this.key = Guid.NewGuid().ToString();
    }

    public string Key
    {
      get { return key; }
    }


    protected override object SynchronizedGetValue()
    {
      return storage.GetObject(key); 
    }

    protected override void SynchronizedSetValue(object newValue)
    {
      storage.StoreObject(key, newValue);
    }

    public override void RemoveValue()
    {
      Dispose();
    }

    public void Dispose()
    {
      Dispose(true);
      GC.SuppressFinalize(this); 
    }

    protected void Dispose(bool disposing)
    {
      if (storage != null)
      {
        storage.RemoveObject(key);
        storage = null;
      }
    }
  }
}
