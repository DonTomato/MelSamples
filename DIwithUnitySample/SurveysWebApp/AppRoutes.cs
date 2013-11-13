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
using System.Web;

namespace SurveysWebApp
{
  using System.Web.Mvc;
  using System.Web.Routing;

  public static class AppRoutes
  {
    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.MapRoute(
          "Management",
          "",
          new { controller = "Management", action = "Index" });

      routes.MapRoute(
          "Management-Detail",
          "Management/{tenant}",
          new { controller = "Management", action = "Detail" });

      routes.MapRoute(
                "MySurveys",
                "survey/{tenant}",
                new { controller = "Surveys", action = "Index" });

      routes.MapRoute(
                "BrowseResponses",
                "survey/{tenant}/{surveySlug}/{answerId}",
                new { controller = "Surveys", action = "BrowseResponses", answerId = string.Empty });
    }
  }
}
