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

using System.Collections.Generic;

namespace Surveys.MessageQueues
{
  interface IMessageQueue<T>
  {
    void EnsureExist();
    void Clear();
    void AddMessage(T message);
    T GetMessage();
    IEnumerable<T> GetMessages(int maxMessagesToReturn);
    void DeleteMessage(T message);
  }
}
