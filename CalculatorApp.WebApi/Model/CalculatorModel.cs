using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
namespace CalculatorApp.WebApi.Model
{
    public class CalculatorModel 
    {
        [JsonPropertyName("firstNumber")] 
        [Required]
        public int FirstNumber { get; set; }
        [Required]
        [JsonPropertyName("secondNumber")]
        public int SecondNumber { get; set; }
        [Required]
        [JsonPropertyName("operation")]
        public string Operation { get; set; }   

       

    }
}
