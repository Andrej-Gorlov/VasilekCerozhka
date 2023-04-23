namespace VasilekCerozhka.Identity.ResponseAuth
{
    public class AuthResponse
    {
        public Status Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public ResultAuthorization? resultAuth { get; set; }
    }
    public class ResultAuthorization
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
    public enum Status
    {
        NotFound,
        PasswordInvalid,
        Authorized,
        Unauthorized,
        Exists, // user already registered
        Mismatch,
        NotCreated,
        UpdatedRole
    }
}
