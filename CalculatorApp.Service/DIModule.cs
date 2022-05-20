using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Core.Interfaces;
using CalculatorApp.Core;
using CalculatorApp.Database.Interfaces;
using CalculatorApp.Database;

namespace CalculatorApp.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
           this.Bind<ISimpleCalculator>().To<SimpleCalculator>();
           this.Bind<IDiagnosticsDetails>().To<DiagnosticDetails>();
           this.Bind<ICalculatAppOperationDetailRepository>().To<CalculatAppOperationDetailRepository>();
        }
    }
}
