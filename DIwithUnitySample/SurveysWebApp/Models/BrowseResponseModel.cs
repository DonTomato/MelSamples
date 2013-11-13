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

namespace SurveysWebApp.Models
{
  public class BrowseResponseModel
  {
    public SurveyAnswer SurveyAnswer { get; set; }

    public string NextAnswerId { get; set; }

    public string ThisAnswerId { get; set; }

    public string PreviousAnswerId { get; set; }

    public bool CanMoveForward
    {
      get
      {
        return !string.IsNullOrEmpty(this.NextAnswerId);
      }
    }

    public bool CanMoveBackward
    {
      get
      {
        return !string.IsNullOrEmpty(this.PreviousAnswerId);
      }
    }
  }
}
