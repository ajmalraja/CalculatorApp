using CalculatorApp.Core.Interfaces;
using CalculatorApp.Database.Interfaces;
using CalculatorApp.Database.Model;
using CalculatorApp.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Service.Services
{
    public class CalculatorDBService : ICalculatorDBService
    {
        private readonly ICalculatAppOperationDetailRepository _operationalDetails;
        private readonly ISimpleCalculator _simplecalculator;
        public CalculatorDBService(ISimpleCalculator simplecalculator,
                                ICalculatAppOperationDetailRepository operationalDetails)
        {
            _simplecalculator = simplecalculator;
            _operationalDetails=operationalDetails; 
        }

        public int DoTheCalculationLogInDB(int firstparameter, int secondparameter, string operation)
        {
            var opr = _simplecalculator.GetType().GetMethod(operation);

            if (opr == null)
            {
                _operationalDetails.Add(
                    new CalculatAppOperationDetail
                    {
                        FirstParameter=firstparameter.ToString(),
                        SecondParameter=secondparameter.ToString(),
                        OPerator=operation,
                        Result="Invalid  Operation"                        
                    }
                    ); 
                return 0;
            }

            var sw = new Stopwatch();
            sw.Start();
            var result = opr.Invoke(_simplecalculator, new object[] { firstparameter, secondparameter });
            sw.Stop();
            _operationalDetails.Add(
                    new CalculatAppOperationDetail
                    {
                        FirstParameter = firstparameter.ToString(),
                        SecondParameter = secondparameter.ToString(),
                        OPerator = operation,
                        ProcessedIn=sw.ElapsedTicks.ToString()+"Ticks",
                        Result = result.ToString(),
                    }
                    );

            return (int)result;
        }
    }
}
