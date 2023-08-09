using System.Net;
using VasilekCerozhka.Services.Interfaces.IAccountsAPI;
using static VasilekCerozhka.Helpers.StaticDitels;

namespace VasilekCerozhka.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly ITokenProvider _tokenProvider;
        public BaseService(ITokenProvider tokenProvider, IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _tokenProvider= tokenProvider;
        }

        public async Task<ResponseDtoBase?> SendAsync(ApiRequest apiRequest, bool withBearer = true)
        {
            try
            {
                HttpClient client = _httpClient.CreateClient("VasilisaAPI");
                HttpRequestMessage message = new();

                if (apiRequest.ContentType == ContentType.MultipartFormData)
                {
                    message.Headers.Add("Accept", "*/*");
                }
                else
                {
                    message.Headers.Add("Accept", "application/json");
                }
                //token
                if (withBearer)
                {
                    var token = _tokenProvider.GetToken();
                    message.Headers.Add("Authorization", $"Bearer {token}");
                }
                message.RequestUri = new Uri(apiRequest.Url);

                if (apiRequest.ContentType == ContentType.MultipartFormData)
                {
                    var content = new MultipartFormDataContent();

                    foreach (var prop in apiRequest.Data.GetType().GetProperties())
                    {
                        var value = prop.GetValue(apiRequest.Data);
                        if (value is FormFile)
                        {
                            var file = (FormFile)value;
                            if (file != null)
                            {
                                content.Add(new StreamContent(file.OpenReadStream()), prop.Name, file.FileName);
                            }
                        }
                        else
                        {
                            content.Add(new StringContent(value == null ? "" : value.ToString()), prop.Name);
                        }
                    }
                    message.Content = content;
                }
                else
                {
                    if (apiRequest.Data != null)
                    {
                        message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
                    }
                }

                HttpResponseMessage? apiResponse = null;

                switch (apiRequest.Api_Type)
                {
                    case StaticDitels.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case StaticDitels.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case StaticDitels.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    case StaticDitels.ApiType.PATCH:
                        message.Method = HttpMethod.Patch;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }

                apiResponse = await client.SendAsync(message);

                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, DisplayMessage = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, DisplayMessage = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, DisplayMessage = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, DisplayMessage = "Internal Server Error" };
                    default:
                        var apiContet = await apiResponse.Content.ReadFromJsonAsync<ResponseDtoBase>();
                        return apiContet;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDtoBase
                {
                    DisplayMessage = ex.Message.ToString(),
                    IsSuccess = false
                };
                return dto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}