using System.Threading.Tasks;
using WebApp.WebStore.Application.Models.Mail;

namespace WebApp.WebStore.Application.Contracts.Infrastructure
{
    public interface IEmailService
    {
        Task<bool> SendEmail(Email email);
    }
}
