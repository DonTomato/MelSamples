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

using System.Diagnostics;
using System.Globalization;
using Microsoft.Practices.Unity;
using Surveys.BlobContainers;
using Surveys.Models;

namespace Surveys.Stores
{
  public class SurveyAnswerContainerFactory : ISurveyAnswerContainerFactory
  {
    private readonly IUnityContainer unityContainer;

    public SurveyAnswerContainerFactory(IUnityContainer unityContainer)
    {
      Trace.WriteLine(string.Format("Called constructor in SurveyAnswerContainerFactory"), "UNITY");

      this.unityContainer = unityContainer;
    }

    public IBlobContainer<SurveyAnswer> Create(string tenant, string surveySlug)
    {
      Trace.WriteLine(string.Format("Called Create in SurveyAnswerContainerFactory with tenant={0}, surveySlug={1}", tenant, surveySlug), "UNITY");

      var blobContainerName = string.Format(
          CultureInfo.InvariantCulture,
          "surveyanswers-{0}-{1}",
          tenant.ToLowerInvariant(),
          surveySlug.ToLowerInvariant());
      return this.unityContainer.Resolve<IBlobContainer<SurveyAnswer>>(
          new ParameterOverride("blobContainerName", blobContainerName));
    }
  }
}
