using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Service.Interfaces
{
    public interface ICalculatorADOService
    {
        int DoTheCalculationLogInDB(int firstparameter, int secondparameter, string operation);
    }
}
