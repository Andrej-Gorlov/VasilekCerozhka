namespace VasilekCerozhka.Models.Accounts
{
    public class AuthenticationDto
    {
        public string? Email { get; set; }
        [Display(Name = "Пароль")]
        public string? Password { get; set; }
        public string? Token { get; set; }

        public string? Result { get; set; }
    }
}
