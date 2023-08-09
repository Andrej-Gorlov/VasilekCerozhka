namespace VasilekCerozhka.Models.Accounts
{
    public class RegisterDto
    {
        [EmailAddress, Required(ErrorMessage = "Введите электронную почту.")]
        public string? Email { get; set; }

        [Required, Display(Name = "Дата рождения")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Пароль"), Required(ErrorMessage = "Введите пароль.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Display(Name = "Подтвердить пароль"), Required(ErrorMessage = "Введите пароль.")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string? PasswordConfirm { get; set; }

        [Display(Name = "Имя"), Required(ErrorMessage = "Введите имя пользователя.")]
        public string? FirstName { get; set; }

        [Display(Name = "Фамилия"), Required(ErrorMessage = "Введите фамилию пользователя.")]
        public string? LastName { get; set; }

        [Display(Name = "Отчество")]
        public string? MiddleName { get; set; }
    }
}
