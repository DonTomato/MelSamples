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

namespace Surveys.MessageQueues
{
  class SurveyAnswerStoredMessage
  {
    public string SurveyAnswerBlobId { get; set; }

    public string Tenant { get; set; }

    public string SurveySlugName { get; set; }

    public bool AppendedToAnswers { get; set; }
  }
}
