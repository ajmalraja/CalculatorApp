using CalculatorApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core
{
    public class DiagnosticDetails : IDiagnosticsDetails
    {
       
        public void ShowOutputToConsole(int firstParameter, int secondParameter, string operation, int result)
        {
            
            Console.WriteLine($"FirstParameter:{firstParameter.ToString()}");
            Console.WriteLine($"SecondParameter:{secondParameter.ToString()}");
            Console.WriteLine($"Operation:{operation}");
            Console.WriteLine($"Result:{result.ToString()}");
           
        }

        public void ShowOutputToConsole(string ErrMessage)
        {
            Console.WriteLine(ErrMessage);
            Console.WriteLine("The Available operation are (Add,Subtract,Multiply,Divide");
        }
    }
}
