using CalculatorApp.Core.Interfaces;
using CalculatorApp.Database.Interfaces;
using CalculatorApp.Service.Interfaces;
using CalculatorApp.WebApi.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CalculatorApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorDBService _calculatordbservice;
        private readonly ILogger _logger;
        public CalculatorController(ICalculatorDBService calculatordbservice,ILogger logger)
        {            
            _calculatordbservice=calculatordbservice;  
            _logger=logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation($"{DateTime.Now}:-Check Alive passed");
            return "Alive";
        }


        // POST api/<CalculatorController>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] CalculatorModel calulatormodel)
        {
            _logger.LogInformation($"{DateTime.Now}:- post method was called");

            if (!ModelState.IsValid)
            {
                _logger.LogInformation($"{DateTime.Now}:- post method was called with invalid model ");

                return new ErrorResponse
                {
                    StatusCode=HttpStatusCode.BadRequest,
                    Message="Invalid Model"                    
                };
            }
            
            if (!CalculatorAppHelpercs.ValidateOperations(calulatormodel.Operation))
            {
                _logger.LogInformation($"{DateTime.Now}:- post method was called with invalid operation ");

                return new ErrorResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Error in processing",
                    Reason="Invalid Operation",

                };
            }

            _logger.LogInformation($"{DateTime.Now}:- called the calculatordbservice FirstNumber=>{calulatormodel.FirstNumber} SecondNumber=>{calulatormodel.SecondNumber}" +
                                    $" Operation=>{calulatormodel.Operation} ");

            var res=_calculatordbservice.DoTheCalculationLogInDB(calulatormodel.FirstNumber, calulatormodel.SecondNumber, calulatormodel.Operation);

            return new ValidResponse
            {
                StatusCode = HttpStatusCode.OK,
                FirstNumber = calulatormodel.FirstNumber.ToString(),
                SecondNumber = calulatormodel.SecondNumber.ToString(),
                Operation = calulatormodel.Operation,
                Result = res.ToString(),
                
            };


        }

    } 

            
}
    
