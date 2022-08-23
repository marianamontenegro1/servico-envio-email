using ServicoWindows.Models;
using System.Threading.Tasks;

namespace ServicoWindows.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(EmailRequest emailRequest);
    }
}
