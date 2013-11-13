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

namespace Surveys.MessageQueues
{
  class MessageQueue<T> : StorageWithRetryPolicyFactory,  IMessageQueue<T>
  {
    private readonly StorageAccount account;
    private readonly TimeSpan visibilityTimeout;
    private readonly string queue;

    public MessageQueue(StorageAccount account, IRetryPolicyFactory retryPolicyFactory)
      : this(account, retryPolicyFactory, typeof(T).Name.ToLowerInvariant())
    {
    }

    public MessageQueue(StorageAccount account, IRetryPolicyFactory retryPolicyFactory, string queueName)
      : this(account, retryPolicyFactory, queueName, TimeSpan.FromSeconds(30))
    {
    }

    public MessageQueue(StorageAccount account, IRetryPolicyFactory retryPolicyFactory, string queueName, TimeSpan visibilityTimeout) : base(retryPolicyFactory)
    {
      Trace.WriteLine(string.Format("Called constructor in MessageQueue with account={0}, queueName={1}, visibilityTimeout={2}", account.ConnectionString, queueName, visibilityTimeout.Seconds), "UNITY");
      this.account = account;
      this.queue = queueName;
      this.visibilityTimeout = visibilityTimeout;
    }

    public void EnsureExist()
    {
      Trace.WriteLine(string.Format("Checking MessageQueue {0} exists", queue), "UNITY");
    }

    public void Clear()
    {
      throw new NotImplementedException();
    }

    public void AddMessage(T message)
    {
      throw new NotImplementedException();
    }

    public T GetMessage()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<T> GetMessages(int maxMessagesToReturn)
    {
      throw new NotImplementedException();
    }

    public void DeleteMessage(T message)
    {
      throw new NotImplementedException();
    }
  }
}
