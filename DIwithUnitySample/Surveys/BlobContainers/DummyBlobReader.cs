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
using Surveys.Models;

namespace Surveys.BlobContainers
{
  class DummyBlobReader<T>
  {
    internal static object GetBlob(string objId)
    {
      if (typeof(T) == typeof(List<string>))
      {
        string[] answerlist = { "1", "2", "3", "4", "5", "6" };
        List<string> al = new List<string>(answerlist);
        return al;
      }

      if (typeof(T) == typeof(SurveyAnswer))
      {
        List<QuestionAnswer> answers = new List<QuestionAnswer>();
        QuestionAnswer answer;
        for (int i = 1; i < 11; i++)
        {
          answer = new QuestionAnswer()
          {
            Answer = "The answer to question " + i,
            QuestionText = "Question " + i,
            QuestionType = QuestionType.SimpleText
          };
          answers.Add(answer);
        }

        SurveyAnswer surveyAnswer = new SurveyAnswer()
        {
          CreatedOn = DateTime.Now,
          QuestionAnswers = answers,
          SlugName = "SlugName",
          Tenant = "Tenant",
          Title = "Title"
        };
        return surveyAnswer;
      }

      if (typeof(T) == typeof(Tenant))
      {
        if (objId.Equals("Adatum"))
        {
          return new Tenant
          {
            Name = "Adatum",
            HostGeoLocation = "Anywhere US",
            WelcomeText = "Adatum is a sample compaany",
            SubscriptionKind = Models.SubscriptionKind.Premium,
            IssuerIdentifier = "http://adatum/trust",
            IssuerUrl = "https://localhost/Adatum.SimulatedIssuer.v2/",
            IssuerThumbPrint = "f260042d59e14817984c6183fbc6bfc71baf5462",
            ClaimType = "http://schemas.xmlsoap.org/claims/group",
            ClaimValue = "Marketing Managers",
          };
        }
        else if (objId.Equals("Fabrikam"))
        {
          return new Tenant
          {
            Name = "Fabrikam",
            HostGeoLocation = "Anywhere US",
            WelcomeText = "Fabrikam is a sample compaany",
            SubscriptionKind = Models.SubscriptionKind.Standard,
            IssuerIdentifier = "http://fabrikam/trust",
            IssuerUrl = "https://localhost/Fabrikam.SimulatedIssuer.v2/",
            IssuerThumbPrint = "d2316a731b59683e744109278c80e2614503b17e",
            ClaimType = "http://schemas.xmlsoap.org/claims/group",
            ClaimValue = "Marketing Managers",
          };
        }
        else if (objId.Equals("Contoso"))
        {
          return new Tenant
          {
            Name = "Contoso",
            HostGeoLocation = "Anywhere US",
            WelcomeText = "Contoso is a sample compaany",
            SubscriptionKind = Models.SubscriptionKind.Premium,
            IssuerIdentifier = "http://contoso/trust",
            IssuerUrl = "https://localhost/Contoso.SimulatedIssuer.v2/",
            IssuerThumbPrint = "e5913a731b59683e744109278c80e2614504a618",
            ClaimType = "http://schemas.xmlsoap.org/claims/group",
            ClaimValue = "Marketing Managers",
          };
        }
        else
        {
          return new Tenant()
          {
            Name = "tenant",
            HostGeoLocation = "Anywhere US",
            WelcomeText = "Another sample compaany",
            SubscriptionKind = Models.SubscriptionKind.Premium,
            IssuerIdentifier = "http://another/trust",
            IssuerUrl = "https://localhost/Another.SimulatedIssuer.v2/",
            IssuerThumbPrint = "f260042d59e14817984c6183fbc6bfc71baf5462",
            ClaimType = "http://schemas.xmlsoap.org/claims/group",
            ClaimValue = "Marketing Managers",
          };
        }

        
      }
      return null;
    }

    internal static IEnumerable<IListBlobItemWithName> ListBlobs()
    {
      if (typeof(T) == typeof(Tenant))
      {
        List<DummyBlob> list = new List<DummyBlob>();
        list.Add(new DummyBlob { Name = "Adatum" });
        list.Add(new DummyBlob { Name = "Fabrikam" });
        list.Add(new DummyBlob { Name = "Contoso" });
        list.Add(new DummyBlob { Name = "tenant" });
        return list;
      }
      return null;
    }
  }
}
