
using System.Net;
using System.Text.Json.Serialization;
namespace CalculatorApp.WebApi.Model
{
    public class ErrorResponse : HttpResponseMessage
    {
        
        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("reason")]
        public string Reason { get; set; }

       
    }
}
