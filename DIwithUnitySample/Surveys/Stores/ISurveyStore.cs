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
  public interface ISurveyStore
  {
    void Initialize();
    void SaveSurvey(Survey survey);
    void DeleteSurveyByTenantAndSlugName(string tenant, string slugName);
    Survey GetSurveyByTenantAndSlugName(string tenant, string slugName, bool getQuestions);
    IEnumerable<Survey> GetSurveysByTenant(string tenant);
    IEnumerable<Survey> GetRecentSurveys();
  }
}
