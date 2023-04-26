using System.Data;

namespace VasilekCerozhka.Identity.ServicesAuth.ImplementationsAuth
{
    public class AccountServicesAuth: IAccountServicesAuth
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<AccountServicesAuth> _logger;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AuthResponse response;
        private readonly Token token;

        public AccountServicesAuth(ILogger<AccountServicesAuth> logger, IConfiguration configuration, ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _logger = logger;
            _userManager = userManager;
            _configuration = configuration;
            response = new();
            token = new(configuration);
        }

        /// <summary>
        /// Регистрация пользовотеля.
        /// </summary>
        /// <param name="register"></param>
        /// <returns>Зарегистрированного пользовотеля.</returns>
        public async Task<AuthResponse> RegisterAsync(RegisterDto register)
        {
            _logger.LogInformation($"Регистрация пользовотеля. / method: Register");
            if (register.Password != register.PasswordConfirm)
            {
                _logger.LogWarning($"Пароли не совпадают.");
                response.Status = Status.Mismatch;
                response.Message = $"Пароли не совпадают.";
                return response;
            }

            var isExistsUser = await _userManager.FindByNameAsync(register.Email);
            if (isExistsUser != null) return UserNotFound(register.Email);

            var newUser = new ApplicationUser
            {
                UserName = register.Email,
                FirstName = register.FirstName,
                LastName = register.LastName,
                MiddleName = register.MiddleName,
                Email = register.Email,
                BirthDate= register.BirthDate,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            var createUserResult = await _userManager.CreateAsync(newUser, register.Password);

            if (!createUserResult.Succeeded)
            {
                var errorString = "Не удалось создать пользователя, потому что: ";
                foreach (var error in createUserResult.Errors)
                {
                    errorString += " # " + error.Description;
                }
                _logger.LogWarning(errorString);
                response.Status = Status.NotCreated;
                response.Message = errorString;
                return response;
            }
            // Add a Default USER Role to all users
            _logger.LogWarning($"Добавление роли по умолчанию (USER).");
            await _userManager.AddToRoleAsync(newUser, "admin");
            return await AuthenticateAsync(new() { Email ="",Password=""});
        }
        /// <summary>
        /// Аутентификация пользовотеля.
        /// </summary>
        /// <param name="register"></param>
        /// <returns>Авторизованного пользовотеля.</returns>
        public async Task<AuthResponse> AuthenticateAsync(AuthenticationDto authen)
        {
            _logger.LogInformation($"Аутентификация пользовотеля. / method: Authenticate");
            var managedUser = await _userManager.FindByEmailAsync(authen.Email);
            if (managedUser is null) return UserNotFound(authen.Email);

            var isPasswordValid = await _userManager.CheckPasswordAsync(managedUser, authen.Password);
            if (!isPasswordValid)
            {
                _logger.LogWarning("Неверный пароль.");
                response.Status = Status.PasswordInvalid;
                response.Message = "Неверный пароль.";
                return response;
            }

            var user = _db.Users.FirstOrDefault(u => u.Email == authen.Email);
            if (user is null)
            {
                _logger.LogWarning("Пользователь неавторизован.");
                response.Status = Status.Unauthorized;
                response.Message = "Пользователь неавторизован.";
                return response;
            }

            var roleIds = await _db.UserRoles.Where(r => r.UserId == user.Id).Select(x => x.RoleId).ToListAsync();
            var roles = _db.Roles.Where(x => roleIds.Contains(x.Id)).ToList();

            _logger.LogWarning("Cоздание токена.");
            var accessToken = token.CreateToken(user, roles);
            user.RefreshToken = _configuration.GenerateRefreshToken();
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(_configuration.GetSection("Jwt:RefreshTokenValidityInDays").Get<int>());

            _logger.LogWarning("Сохраненные в бд.");
            await _db.SaveChangesAsync();





            response.resultAuth = Authenticate(user, accessToken, roles);
            _logger.LogWarning("Пользователь авторизован.");
            response.Status = Status.Authorized;
            response.RefreshTokenExpiryTime = user.RefreshTokenExpiryTime;
            response.Message = "Пользователь авторизован.";
            return response;
        }
        /// <summary>
        /// Обновление роли (ADMIN).
        /// </summary>
        /// <param name="updateUser"></param>
        /// <returns>Пользователя обновившего роль (ADMIN).</returns>
        public async Task<AuthResponse> MakeAdminAsync(UpdateUserPermissionDto updateUser)
        {
            _logger.LogInformation($"Обновление роли (ADMIN). / method: MakeAdminAsync");
            var user = await _userManager.FindByNameAsync(updateUser.Email);
            if (user is null) return UserNotFound(updateUser.Email);

            _logger.LogWarning($"Обновление роли (ADMIN).");
            await _userManager.AddToRoleAsync(user, StaticUserRoles.ADMIN);

            _logger.LogWarning($"Роль пользователь {user.UserName} обновлена (ADMIN).");
            response.Status = Status.UpdatedRole;
            response.Message = $"Роль пользователь {user.UserName} обновлена (ADMIN).";

            //response.resultAuth = new()
            //{
            //    Username = user.UserName,
            //    Email = user.Email,
            //};

            return response;
        }
        /// <summary>
        /// Обновление роли (OWNER).
        /// </summary>
        /// <param name="updateUser"></param>
        /// <returns>Пользователя обновившего роль (OWNER).</returns>
        public async Task<AuthResponse> MakeOwnerAsync(UpdateUserPermissionDto updateUser)
        {
            _logger.LogInformation($"Обновление роли (OWNER). / method: MakeOwnerAsync");
            var user = await _userManager.FindByNameAsync(updateUser.Email);
            if (user is null) return UserNotFound(updateUser.Email);

            _logger.LogWarning($"Обновление роли (ADMIN).");
            await _userManager.AddToRoleAsync(user, StaticUserRoles.OWNER);

            _logger.LogWarning($"Роль пользователь {user.UserName} обновлена (OWNER).");
            response.Status = Status.UpdatedRole;
            response.Message = $"Роль пользователь {user.UserName} обновлена (OWNER).";

            //response.resultAuth = new()
            //{
            //    Username = user.UserName,
            //    Email = user.Email,
            //};

            return response;
        }

        private AuthResponse UserNotFound(string email)
        {
            _logger.LogWarning($"Пользователь с {email} не найден.");
            response.Status = Status.NotFound;
            response.Message = $"Пользователь с {email} не найден.";
            return response;
        }

        private ClaimsIdentity Authenticate(ApplicationUser user, string token, List<IdentityRole<long>> roles)

        {
            var claims = new List<Claim>
            {
                new Claim(JwtClaimTypes.Name, user.FirstName+" "+user.LastName+" "+ user.MiddleName),
                new Claim(JwtClaimTypes.GivenName, user.FirstName),
                new Claim(JwtClaimTypes.FamilyName, user.LastName),
                new Claim(JwtClaimTypes.MiddleName, user.MiddleName),
                new Claim(JwtClaimTypes.Email, user.Email),
                new Claim(JwtClaimTypes.BirthDate, user.BirthDate.ToString()),
                new Claim(JwtClaimTypes.ReferenceTokenId, user.RefreshToken),
                new Claim(JwtClaimTypes.AccessTokenHash, token),
                new Claim(JwtClaimTypes.Role, string.Join(" ", roles.Select(x => x.Name)))
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}
