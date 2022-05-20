using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Database.Model
{
    public class CalculatAppOperationDetail
    {
        [Key]
        public int ID { get; set; }
        public string FirstParameter { get; set; }
        public string SecondParameter { get; set; }
        public string OPerator { get; set; }
        public string Result { get; set; }
        public string ProcessedIn { get; set; }
       

    }
}
