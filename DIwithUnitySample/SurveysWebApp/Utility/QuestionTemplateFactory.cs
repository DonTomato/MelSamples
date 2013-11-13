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

using Surveys.Models;

namespace SurveysWebApp.Utility
{
  public static class QuestionTemplateFactory
  {
    public static string Create(QuestionType questionType)
    {
      switch (questionType)
      {
        case QuestionType.SimpleText:
          return "SimpleText";
        case QuestionType.MultipleChoice:
          return "MultipleChoice";
        case QuestionType.FiveStars:
          return "FiveStars";
        default:
          return "String";
      }
    }
  }
}
