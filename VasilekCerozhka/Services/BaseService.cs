﻿using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using VasilekCerozhka.Helpers;
using VasilekCerozhka.Models;
using VasilekCerozhka.Services.IServices;

namespace VasilekCerozhka.Services
{
    public class BaseService : IBaseService
    {
        public ResponseDtoBase responseModel { get; set; }
        public IHttpClientFactory? httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient)
        {
            this.responseModel = new ResponseDtoBase();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(ApiRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("VasilisaAPI");

                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                client.DefaultRequestHeaders.Clear();
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        Encoding.UTF8, "application/json");
                }

                if (!string.IsNullOrEmpty(apiRequest.AccessToken))
                {
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
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

                apiResponse = await client.SendAsync(message); // Узнать сообщения от ModelState!
                var apiContet = await apiResponse.Content.ReadAsStringAsync();

                if (apiResponse.Headers.FirstOrDefault(x => x.Key == "X-Pagination").Key != null)
                {
                    var apiHeaders = apiResponse.Headers.GetValues("X-Pagination").FirstOrDefault();

                    var apiResponseDt = JsonConvert.DeserializeObject<T>
                        (apiContet.Substring(0, apiContet.Length - 1)+ ",\"PagedList\":" + apiHeaders + "}");
                    return apiResponseDt;
                }

                var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContet);
                return apiResponseDto;

            }
            catch (Exception ex)
            {
                var dto = new ResponseDtoBase
                {
                    DisplayMessage = "Error",
                    ErrorMessages = new List<string> { Convert.ToString(ex.Message) },
                    IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
                return apiResponseDto;
            }
        }

        public void Dispose()
        {
            GC.SuppressFinalize(true);
        }
    }
}
