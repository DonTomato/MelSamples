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
using Surveys.DataTables;
using Surveys.Models;

namespace Surveys.Stores
{
  class SurveyStore : ISurveyStore
  {
    private readonly IDataTable<SurveyRow> surveyTable;
    private readonly IDataTable<QuestionRow> questionTable;
    private readonly ISurveyAnswerContainerFactory surveyAnswerContainerFactory;

    public SurveyStore(
        IDataTable<SurveyRow> surveyTable,
        IDataTable<QuestionRow> questionTable,
        ISurveyAnswerContainerFactory surveyAnswerContainerFactory)
    {
      Trace.WriteLine(string.Format("Called constructor in SurveyStore"), "UNITY");
      this.surveyTable = surveyTable;
      this.questionTable = questionTable;
      this.surveyAnswerContainerFactory = surveyAnswerContainerFactory;
    }

    public void Initialize()
    {
      Trace.WriteLine(string.Format("Called Initialize in SurveyStore"), "UNITY");
      this.surveyTable.EnsureExist();
      this.questionTable.EnsureExist();
      Console.WriteLine("Initialized a SurveyStore instance");
    }

    public void SaveSurvey(Survey survey)
    {
      throw new NotImplementedException();
    }

    public void DeleteSurveyByTenantAndSlugName(string tenant, string slugName)
    {
      throw new NotImplementedException();
    }

    public Survey GetSurveyByTenantAndSlugName(string tenant, string slugName, bool getQuestions)
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Survey> GetSurveysByTenant(string tenant)
    {
      var survey1 = new Survey(tenant + "-survey1")
      {
        Tenant = tenant,
        Title = tenant + " Survey #1",
        CreatedOn = DateTime.Now.AddDays(-12)
      };
      var survey2 = new Survey(tenant + "-survey2")
      {
        Tenant = tenant,
        Title = tenant + " Survey #2",
        CreatedOn = DateTime.Now.AddDays(-10)
      };
      return new Survey[]{survey1, survey2};
    }

    public IEnumerable<Survey> GetRecentSurveys()
    {
      throw new NotImplementedException();
    }
  }
}
