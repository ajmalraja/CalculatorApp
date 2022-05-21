using CalculatorApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Core
{
    /// <summary>
    /// Calculator Core Operation work only for integer
    /// </summary>

    public class SimpleCalculator : ISimpleCalculator
    {
       
        public int Add(int start, int amount)
        {
            return start + amount;
        }

        public int Divide(int start, int by)
        {
            return start / by;
        }

        public int Multiply(int start, int by)
        {
            return start * by;
        }

        public int Subtract(int start, int amount)
        {
           return start - amount;
        }
    }
}
