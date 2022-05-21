using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.WebClientConsole.Model
{
    public class ErrorResponse
    {
       public string StatusCode { get; set; }

       public string Message { get; set; }

       public string Reason { get; set; }
    }
}
