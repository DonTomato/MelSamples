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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using CalculatorEngines;

namespace CalculatorService
{
  public class CalculatorService : ICalculator
  {
    private ICalculationEngine calculatorEngine;

    public CalculatorService(ICalculationEngine calculatorEngine)
    {
      this.calculatorEngine = calculatorEngine;
    }

    public double Add(double n1, double n2)
    {
      double result = calculatorEngine.Add(n1, n2);
      Console.WriteLine("Received Add({0},{1})", n1, n2);
      Console.WriteLine("Return: {0}", result);
      return result;
    }

    public double Subtract(double n1, double n2)
    {
      double result = calculatorEngine.Subtract(n1, n2);
      Console.WriteLine("Received Subtract({0},{1})", n1, n2);
      Console.WriteLine("Return: {0}", result);
      return result;
    }

    public double Multiply(double n1, double n2)
    {
      double result = calculatorEngine.Multiply(n1, n2);
      Console.WriteLine("Received Multiply({0},{1})", n1, n2);
      Console.WriteLine("Return: {0}", result);
      return result;
    }

    public double Divide(double n1, double n2)
    {
      double result = calculatorEngine.Divide(n1, n2);
      Console.WriteLine("Received Divide({0},{1})", n1, n2);
      Console.WriteLine("Return: {0}", result);
      return result;
    }
  }
}
