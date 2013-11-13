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

namespace Surveys.Models
{
  [Serializable]
  public class Survey
  {
    private readonly string slugName;

    public Survey()
      : this(string.Empty)
    {
    }

    public Survey(string slugName)
    {
      this.slugName = slugName;
      this.Questions = new List<Question>();
    }

    public string SlugName
    {
      get
      {
        return this.slugName;
      }
    }

    public string Tenant { get; set; }

    public string Title { get; set; }

    public DateTime CreatedOn { get; set; }

    public List<Question> Questions { get; set; }
  }
}
