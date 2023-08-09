namespace VasilekCerozhka.Models
{
    public class ResponseDtoBase
    {
        public bool IsSuccess { get; set; } = true;
        public object? Result { get; set; }
        public string DisplayMessage { get; set; } = "";
        public ICollection<string>? ErrorMessages { get; set; }
        public PagedList? ParameterPaged { get; set; }
        public ResultAuthorization? resultAuth { get; set; }
    }
}
