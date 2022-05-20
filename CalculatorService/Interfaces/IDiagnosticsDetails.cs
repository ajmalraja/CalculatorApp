using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core.Interfaces
{
    public interface IDiagnosticsDetails
    {
        void ShowOutputToConsole(int firstParameter, int secondParameter, string Operation, int result);
        void ShowOutputToConsole(string ErrMessage);
    }
}
