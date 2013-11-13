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
using Microsoft.Practices.Unity;

namespace AppIntitializer
{
  public static class ContainerRegistrationsExtension
  {
    public static string GetMappingAsString(
      this ContainerRegistration registration)
    {
      string regName, regType, mapTo, lifetime;

      var r = registration.RegisteredType;
      regType = r.Name + GetGenericArgumentsList(r);

      var m = registration.MappedToType;
      mapTo = m.Name + GetGenericArgumentsList(m);

      regName = registration.Name ?? "[default]";

      lifetime = registration.LifetimeManagerType.Name;
      if (mapTo != regType)
      {
        mapTo = " -> " + mapTo;
      }
      else
      {
        mapTo = string.Empty;
      }
      lifetime = lifetime.Substring(
        0, lifetime.Length - "LifetimeManager".Length);
      return String.Format(
        "+ {0}{1}  '{2}'  {3}", regType, mapTo, regName, lifetime);
    }

    private static string GetGenericArgumentsList(Type type)
    {
      if (type.GetGenericArguments().Length == 0) return "";
      string arglist = "";
      bool first = true;
      foreach (Type t in type.GetGenericArguments())
      {
        arglist += first ? t.Name : ", " + t.Name;
        first = false;
        if (t.GetGenericArguments().Length > 0)
        {
          arglist += GetGenericArgumentsList(t);
        }
      }
      return "<" + arglist + ">";
    }
  }

}
