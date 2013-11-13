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
  class Publisher
  {
    [Publishes("CustomEvent")]
    public event EventHandler RaiseCustomEvent;

    public void DoSomething()
    {
      OnRaiseCustomEvent();

    }

    protected virtual void OnRaiseCustomEvent()
    {
      EventHandler handler = RaiseCustomEvent;

      if (handler != null)
      {
        handler(this, EventArgs.Empty);
      }
    }
  }
}
