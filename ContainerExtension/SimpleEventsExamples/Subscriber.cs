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
using SimpleEventBroker;

namespace SimpleEventsExamples
{
  class Subscriber
  {
    private string id;
    public Subscriber(string ID, Publisher pub)
    {
      id = ID;
      pub.RaiseCustomEvent += HandleCustomEvent;
    }

    public Subscriber(string ID)
    {
      id = ID;
    }

    [SubscribesTo("CustomEvent")]
    public void HandleCustomEvent(object sender, EventArgs e)
    {
      Console.WriteLine("Subscriber {0} received this message at: {1}", id, DateTime.Now);
    }
  }
}
