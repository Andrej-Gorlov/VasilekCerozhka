namespace VasilekCerozhka.Services
{
    public interface IBaseService
    {
        Task<ResponseDtoBase?> SendAsync(ApiRequest apiRequest, bool withBearer = true);
    }
}
