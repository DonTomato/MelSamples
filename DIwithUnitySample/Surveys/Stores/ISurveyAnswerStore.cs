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
using Surveys.Models;

namespace Surveys.Stores
{
  public interface ISurveyAnswerStore
  {
    void Initialize();
    void SaveSurveyAnswer(SurveyAnswer surveyAnswer);
    SurveyAnswer GetSurveyAnswer(string tenant, string slugName, string surveyAnswerId);
    string GetFirstSurveyAnswerId(string tenant, string slugName);
    void AppendSurveyAnswerIdsToAnswersList(string tenant, string slugName, IEnumerable<string> surveyAnswerIds);
    IEnumerable<string> GetSurveyAnswerIds(string tenant, string slugName);
    void DeleteSurveyAnswers(string tenant, string slugName);

    SurveyAnswerBrowsingContext GetSurveyAnswerBrowsingContext(string tenant, string slugName, string answerId);
  }
}
