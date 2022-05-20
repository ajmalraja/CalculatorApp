using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Core.Interfaces;
using CalculatorApp.Core;

namespace CalculatorApp.Service
{
    public class DIModule : NinjectModule
    {
        public override void Load()
        {
           this.Bind<ISimpleCalculator>().To<SimpleCalculator>();
           this.Bind<IDiagnosticsDetails>().To<DiagnosticDetails>();
        }
    }
}
