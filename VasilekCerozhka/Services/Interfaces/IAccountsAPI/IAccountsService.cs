namespace VasilekCerozhka.Services.Interfaces.IAccountsAPI
{
    public interface IAccountsService
    {
        Task<ResponseDtoBase?> Authenticate(AuthenticationDto authentication);
        Task<ResponseDtoBase?> Register(RegisterDto register);
    }
}
