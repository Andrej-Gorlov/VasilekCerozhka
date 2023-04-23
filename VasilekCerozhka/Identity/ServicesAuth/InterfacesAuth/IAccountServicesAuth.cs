namespace VasilekCerozhka.Identity.ServicesAuth.InterfacesAuth
{
    public interface IAccountServicesAuth
    {
        Task<AuthResponse> RegisterAsync(RegisterDto register);
        Task<AuthResponse> AuthenticateAsync(AuthenticationDto authen);
        Task<AuthResponse> MakeAdminAsync(UpdateUserPermissionDto updateUser);
        Task<AuthResponse> MakeOwnerAsync(UpdateUserPermissionDto updateUser);
    }
}
