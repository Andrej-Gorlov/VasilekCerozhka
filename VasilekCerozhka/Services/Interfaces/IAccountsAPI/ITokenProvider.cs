namespace VasilekCerozhka.Services.Interfaces.IAccountsAPI
{
    public interface ITokenProvider
    {

        void SetToken(string token);
        string? GetToken();
        void ClearToken();
    }
}
