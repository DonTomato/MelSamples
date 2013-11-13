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
using System.Runtime.Caching;
using System.Text;
using System.Threading.Tasks;

namespace CustomLifetimeManagers
{
  class SimpleMemoryCache : IStorage
  {
    public object GetObject(string key)
    {
      ObjectCache cache = MemoryCache.Default;
      return cache[key];
    }

    public void StoreObject(string key, object value)
    {
      ObjectCache cache = MemoryCache.Default;
      cache.Set(key, value, null);
    }

    public void RemoveObject(string key)
    {
      ObjectCache cache = MemoryCache.Default;
      cache.Remove(key);
    }
  }
}
