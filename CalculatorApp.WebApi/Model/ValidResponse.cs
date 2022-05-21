using System.Text.Json.Serialization;
namespace CalculatorApp.WebApi.Model
{
    public class ValidResponse:HttpResponseMessage
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("firstNumber")]
        public string FirstNumber { get; set; }

        [JsonPropertyName("secondNumber")]
        public string SecondNumber { get; set; }

        [JsonPropertyName("operation")]
        public string Operation { get; set; }

        [JsonPropertyName("result")]
        public string Result { get; set; }

    }
}
