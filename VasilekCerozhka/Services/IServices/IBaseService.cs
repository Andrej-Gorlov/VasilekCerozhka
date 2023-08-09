﻿namespace VasilekCerozhka.Services.IServices
{
    public interface IBaseService : IDisposable
    {
        Task<ResponseDtoBase?> SendAsync(ApiRequest apiRequest, bool withBearer = true);
    }
}
