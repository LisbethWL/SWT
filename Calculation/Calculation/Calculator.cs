﻿using System;

namespace Calculation
{
    public class Calculator
    {
        public double Add(double a, double b) => a + b;
        public double Subtract(double a, double b) => a - b;
        public double Multiply(double a, double b) => a * b;
        public double Power(double x, double exp) => Math.Pow(x, exp);

        static void Main()
        {

        }
    }
}
