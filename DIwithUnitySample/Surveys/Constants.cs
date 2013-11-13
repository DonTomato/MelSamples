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
using System.Threading.Tasks;

namespace Surveys
{
  public static class Constants
  {
    public const string SurveysTableName = "Surveys";
    public const string QuestionsTableName = "Questions";

    public const string StandardAnswerQueueName = "StandardAnswerQueue";
    public const string PremiumAnswerQueueName = "PremiumAnswerQueue";

    public const string SurveyAnswersListsBlobName = "SurveyAnswersLists";
    public const string TenantsBlobName = "Tenants";
    public const string LogosBlobName = "Logos";

  }
}
