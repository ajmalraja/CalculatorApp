using CalculatorApp.Core;
using CalculatorApp.Core.Interfaces;
using CalculatorApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Service.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ISimpleCalculator _simplecalculator;
        private readonly IDiagnosticsDetails _diagnosticDetails;
        public CalculatorService()
        {
            _simplecalculator = new SimpleCalculator();
            _diagnosticDetails = new DiagnosticDetails();
        }

        public int DoTheCalculationLogonConsole(int firstparameter, int secondparameter,  string operation)
        {
            
            var result = _simplecalculator.GetType().GetMethod(operation).Invoke(_simplecalculator, new object[] { firstparameter, secondparameter });                                          

            _diagnosticDetails.ShowOutputToConsole(firstparameter, secondparameter, operation, (int)result);

            return (int)result;

        }
    }
}
