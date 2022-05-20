using CalculatorApp.Database.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.Database
{
    public class CalculatorAppContext:DbContext
    {

        public CalculatorAppContext():base("name=CalculatorApp")
        {

        }

        public DbSet<CalculatAppOperationDetail> CalculatAppOperationDetail { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CalculatAppOperationDetail>()
                .MapToStoredProcedures(s => s.Insert(u => u.HasName("InsertOperationalDetial", "dbo"))
                                                .Update(u => u.HasName("UpdateOperationalDetial", "dbo"))
                                                .Delete(u => u.HasName("DeleteOperationalDetial", "dbo"))
                );
        }
    }
}
