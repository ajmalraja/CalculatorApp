using CalculatorApp.Service.Interfaces;
using CalculatorApp.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CalculatorApp.Service.Test
{
    [TestClass]
    public class CalculatorServiceTests
    {
        private readonly ICalculatorService _calculatorservice;

        public CalculatorServiceTests()
        {
            _calculatorservice = new CalculatorService();
        }

        [TestMethod]
        public void TestMethod1()
        {
           var res= _calculatorservice.DoTheCalculationLogonConsole(1, 1, "Add");
        }
    }
}
