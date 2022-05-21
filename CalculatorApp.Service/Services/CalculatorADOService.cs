using CalculatorApp.Core.Interfaces;
using CalculatorApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CalculatorApp.Service.Services
{
    /// <summary>
    /// Calculator ADO service
    /// </summary>
    public class CalculatorADOService : ICalculatorADOService
    {
        private readonly ISimpleCalculator _simpleCalculator;
        private readonly IDiagnosticsDetialsADO _diagnosticsDetialsADO;

        public CalculatorADOService(ISimpleCalculator simpleCalculator, IDiagnosticsDetialsADO diagnosticsDetialsADO)
        {
            _simpleCalculator = simpleCalculator;
            _diagnosticsDetialsADO = diagnosticsDetialsADO;
        }

        public int DoTheCalculationLogInDB(int firstparameter, int secondparameter, string operation)
        {
            var opr = _simpleCalculator.GetType().GetMethod(operation);

            if (opr == null)
            {
                _diagnosticsDetialsADO.StoreOutputToDB(firstparameter.ToString(), secondparameter.ToString(), operation,
                                                           "InvalidOperation", string.Empty);                    
                return 0;
            }

            var sw = new Stopwatch();
            sw.Start();
            var result = opr.Invoke(_simpleCalculator, new object[] { firstparameter, secondparameter });
            sw.Stop();
            _diagnosticsDetialsADO.StoreOutputToDB(firstparameter.ToString(), secondparameter.ToString(), operation,
                                                           result.ToString(),sw.ElapsedTicks.ToString());
            return (int)result;
        }
    }
}
