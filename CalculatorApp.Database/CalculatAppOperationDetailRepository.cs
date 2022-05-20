using CalculatorApp.Database.Interfaces;
using CalculatorApp.Database.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Database
{
    public class CalculatAppOperationDetailRepository : ICalculatAppOperationDetailRepository
    {
        private readonly CalculatorAppContext _context;
        public CalculatAppOperationDetailRepository(DbContext context)            
        {
            _context = (CalculatorAppContext)context;
        }

        public bool Add(CalculatAppOperationDetail calculatAppOperationDetail)
        {
            _context.CalculatAppOperationDetail.Add(calculatAppOperationDetail);
            _context.SaveChanges();
            return true;
        }

        public List<CalculatAppOperationDetail> GetAll()
        {
            return _context.CalculatAppOperationDetail.ToList();
        }
    }
}
