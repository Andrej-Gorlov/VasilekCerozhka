using static VasilekCerozhka.Helpers.StaticDitels;

namespace VasilekCerozhka.Models
{
    public class ApiRequest
    {
        public ApiType Api_Type { get; set; } = ApiType.GET;
        public string? Url { get; set; } 
        public object? Data { get; set; } 
        public string? AccessToken { get; set; }
    }
}
