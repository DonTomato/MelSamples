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

namespace Surveys.Models
{
  public class SurveyAnswer
  {
    public SurveyAnswer()
    {
      this.QuestionAnswers = new List<QuestionAnswer>();
    }

    public string SlugName { get; set; }

    public string Tenant { get; set; }

    public string Title { get; set; }

    public DateTime CreatedOn { get; set; }

    public IList<QuestionAnswer> QuestionAnswers { get; set; }
  }
}
