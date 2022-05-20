using CalculatorApp.Core.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CalculatorApp.Core.Tests
{
    /// <summary>
    /// Summary description for DiagnosticDetailTest
    /// </summary>
    [TestClass]
    public class DiagnosticDetailTest
    {
        private readonly IDiagnosticsDetails _diagnosticDetails;
        public DiagnosticDetailTest()
        {
            _diagnosticDetails = new DiagnosticDetails();
        }

        [TestMethod]
        public void Check_The_Order_Of_The_Display_In_Console()
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                _diagnosticDetails.ShowOutputToConsole(1, 1, "ADD",2);
                var firstLine = string.Format("FirstParameter:1{0}", Environment.NewLine);
                StringAssert.Contains(sw.ToString().Substring(0,25), firstLine);
                var lastLine = string.Format("Result:2{0}", Environment.NewLine);
                StringAssert.Contains(sw.ToString().Substring(sw.ToString().Length-10, 10), lastLine);
            }
            

        }
    }
}
