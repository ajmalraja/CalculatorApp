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

        public CalculatorController(ICalculatorDBService calculatordbservice)
        {            
            _calculatordbservice=calculatordbservice;            
        }

        [HttpGet]
        public string Get()
        {
            return "Alive";
        }


        // POST api/<CalculatorController>
        [HttpPost]
        public HttpResponseMessage Post([FromBody] CalculatorModel calulatormodel)
        {          

            if (!ModelState.IsValid)
            {
                return new ErrorResponse
                {
                    StatusCode=HttpStatusCode.BadRequest,
                    Message="Invalid Model"                    
                };
            }
            
            if (!CalculatorAppHelpercs.ValidateOperations(calulatormodel.Operation))
            {
                return new ErrorResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Message = "Error in processing",
                    Reason="Invalid Operation",

                };
            }

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
    
