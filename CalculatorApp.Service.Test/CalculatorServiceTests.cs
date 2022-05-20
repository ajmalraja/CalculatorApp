using CalculatorApp.Core.Interfaces;
using CalculatorApp.Service.Interfaces;
using CalculatorApp.Service.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using FakeItEasy;


namespace CalculatorApp.Service.Test
{
    [TestClass]
    public class CalculatorServiceTests
    {
        private readonly ICalculatorService _calculatorservice;
        private readonly ISimpleCalculator _simpleCalculator;
        private readonly IDiagnosticsDetails _diagnosticsDetails;
       

        public CalculatorServiceTests()
        {
            _simpleCalculator = A.Fake<ISimpleCalculator>();
            _diagnosticsDetails = A.Fake<IDiagnosticsDetails>();          
            _calculatorservice = new CalculatorService(_simpleCalculator, _diagnosticsDetails);
        }

        [TestMethod]
        public void LogOnConsole_With_Existing_Method_Name()
        {
            A.CallTo(() => _simpleCalculator.Add(A<int>._, A<int>._)).Returns(2);
            A.CallTo(() => _diagnosticsDetails.ShowOutputToConsole(A<int>._, A<int>._,A<string>._, A<int>._)).Invokes(
                () =>{

                    Console.WriteLine($"FirstParameter:1");
                    Console.WriteLine($"SecondParameter:1");
                    Console.WriteLine($"Operation:Add");
                    Console.WriteLine($"Result:2");

                });
          

            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var res = _calculatorservice.DoTheCalculationLogonConsole(1, 1, "Add");
                var firstLine = string.Format("FirstParameter:1{0}", Environment.NewLine);
                StringAssert.Contains(sw.ToString().Substring(0, 25), firstLine);
                var lastLine = string.Format("Result:2{0}", Environment.NewLine);
                StringAssert.Contains(sw.ToString().Substring(sw.ToString().Length - 10, 10), lastLine);
            }
           
        }

        [TestMethod]
        public void Log_Error_OnConsole_When_Non_Existing_Method_Name_Used()
        {
            A.CallTo(() => _simpleCalculator.Add(A<int>._, A<int>._)).Returns(2);
            A.CallTo(() => _diagnosticsDetails.ShowOutputToConsole( A<string>._)).Invokes(
                () => {

                    Console.WriteLine($"InvalidOption->Exp");                   

                });
           
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                var res = _calculatorservice.DoTheCalculationLogonConsole(1, 1, "Exp");
                var outputLine = string.Format("InvalidOption->Exp{0}", Environment.NewLine);
                StringAssert.Contains(sw.ToString(), outputLine);
               
            }

        }


    }
}
