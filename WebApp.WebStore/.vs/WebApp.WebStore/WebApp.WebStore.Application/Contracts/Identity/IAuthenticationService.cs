using System.Threading.Tasks;
using WebApp.WebStore.Application.Models.Authentication;

namespace WebApp.WebStore.Application.Contracts.Identity
{
    public interface IAuthenticationService
    {
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request);
        Task<RegistrationResponse> RegisterAsync(RegistrationRequest request);
    }
}
