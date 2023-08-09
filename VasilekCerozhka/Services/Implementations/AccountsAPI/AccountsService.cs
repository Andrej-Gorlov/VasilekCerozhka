namespace VasilekCerozhka.Services.Implementations.AccountsAPI
{
    public class AccountsService : IAccountsService
    {
        private readonly IBaseService _baseService;
        public AccountsService(IBaseService baseService)
        {
            _baseService = baseService;
        }

        public async Task<ResponseDtoBase?> Authenticate(Models.Accounts.AuthenticationDto authentication)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = authentication,
                Url = StaticDitels.AuthApiBase + "/api/accounts/login",
            });
        }

        public async Task<ResponseDtoBase?> Register(Models.Accounts.RegisterDto register)
        {
            return await _baseService.SendAsync(new ApiRequest()
            {
                Api_Type = StaticDitels.ApiType.POST,
                Data = register,
                Url = StaticDitels.AuthApiBase + "/api/accounts/register",
            });
        }
    }
}
