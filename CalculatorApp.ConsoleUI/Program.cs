using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp.Core;
using CalculatorApp.Database;
using CalculatorApp.Service.Interfaces;
using CalculatorApp.Service.Services;

namespace CalculatorApp.ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            string opt = "Y";
            do{
                Console.WriteLine("Please Enter the FirstNumber:");

                var firstInput = Console.ReadLine();

                Console.WriteLine("Please Enter the SecondNumber:");

                var secondInput = Console.ReadLine();

                Console.WriteLine("Please Enter the Operation");

                var operation = Console.ReadLine();

                ValidateAndProcess(firstInput, secondInput, operation);

                 Console.ReadLine();

                Console.WriteLine("Do you want to Continue Y/N");

                opt = Console.ReadLine().ToUpper();
               
            }while(opt != "N");
           
        }

         public static T CreateService<T>(int mode)
        {
            var simpleCalculator=new SimpleCalculator();
            var diagnosticDetails = new DiagnosticDetails();
            var operationDetailRepo = new CalculatAppOperationDetailRepository(new CalculatorAppContext());          
              
            if (mode == 1)
            
                return (T)Convert.ChangeType(new CalculatorDBService(simpleCalculator, operationDetailRepo),typeof(T));

            return (T)Convert.ChangeType(new CalculatorService(simpleCalculator, diagnosticDetails), typeof(T));
        }

        public static void ValidateAndProcess(string firstInput,string secondInput,string operation)
        {
            int firstNum=0;
            int secondNum=0;
           
            if (!int.TryParse(firstInput, out firstNum))
                Console.WriteLine("Invalid FirstNumber:");
            if (!int.TryParse(secondInput, out secondNum))
                Console.WriteLine("Invalid SecondNumber:");

            var calculator = CreateService<CalculatorService>(0);
            calculator.DoTheCalculationLogonConsole(firstNum, secondNum, operation);

            var calculatordb = CreateService<CalculatorDBService>(1);
            calculatordb.DoTheCalculationLogInDB(firstNum, secondNum, operation);
        }
    }
}
