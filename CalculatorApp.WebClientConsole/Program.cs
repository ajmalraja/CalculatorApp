using CalculatorApp.WebClientConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorApp.WebClientConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string opt = "Y";
            do
            {
                var request = new RequestModel();
                Console.WriteLine("Please Enter the FirstNumber:");

                var firstInput = Console.ReadLine();

                Console.WriteLine("Please Enter the SecondNumber:");

                var secondInput = Console.ReadLine();

                Console.WriteLine("Please Enter the Operation");

                var operation = Console.ReadLine();

                CallWebApi(firstInput, secondInput, operation);

                Console.ReadLine();

                Console.WriteLine("Do you want to Continue Y/N");

                opt = Console.ReadLine().ToUpper();

            } while (opt != "N");
        }

        public static async void CallWebApi(string firstNum, string secondNum, string operation)
        {
            var weburl = ConfigurationSettings.AppSettings.Get("WebApiUrl");

            var firstparam = 0;
            var secondparam = 0;

            if (!int.TryParse(firstNum, out firstparam) || !int.TryParse(firstNum, out secondparam))
            {
                Console.WriteLine("Invalid Input");
                return;
            }

            try
            {
                using (var client = new HttpClient())
                {
                    Console.WriteLine($"Calling the WebAPI:{weburl}");
                    var checkAlive = client.GetAsync(weburl);
                    checkAlive.Wait();

                    if (!checkAlive.Result.IsSuccessStatusCode)
                        Console.WriteLine("Error in Processing Web Request");

                    Console.WriteLine("Creating the Model");

                    var request = new RequestModel
                    {
                        FirstNumber = firstparam,
                        SecondNumber = secondparam,
                        Operation = operation
                    };

                    var processReq = client.PostAsJsonAsync<RequestModel>(weburl, request);

                    processReq.Wait();

                    var response = processReq.Result;

                    if (response.IsSuccessStatusCode)
                    {
                       var contentres= response.Content.ReadAsStringAsync().Result;                        

                       var result = JsonConvert.DeserializeObject<Response>(contentres);
                        
                        if (result.StatusCode!="200")
                        {
                           var errResponse = JsonConvert.DeserializeObject<ErrorResponse>(contentres);
                           Console.WriteLine($" {errResponse.StatusCode}  {errResponse.Message} {errResponse.Reason} ");
                        }
                            
                        Console.WriteLine($" {result.FirstNumber}  {result.Operation} {result.SecondNumber} = {result.Result} ");                        

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
