using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core.Interfaces
{
    public interface IDiagnosticsDetialsADO
    {
        void StoreOutputToDB(string firstParameter, string secondParameter, string Operation, string result, string processedIn);
    }
}
