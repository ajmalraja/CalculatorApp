using CalculatorApp.Database.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Database.Interfaces
{
    public interface ICalculatAppOperationDetailRepository
    {
        bool Add(CalculatAppOperationDetail calculatAppOperationDetail);
        List<CalculatAppOperationDetail> GetAll();
    }
}
