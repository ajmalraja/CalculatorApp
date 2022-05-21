using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.WebClientConsole.Model
{
    public class Response
    {
        public string StatusCode { get; set; }

        public string FirstNumber { get; set; }

        public string SecondNumber { get; set; }

        public string Operation { get; set; }

        public string Result { get; set; }

        
    }
}
