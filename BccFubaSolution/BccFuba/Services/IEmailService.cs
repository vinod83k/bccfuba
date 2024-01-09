using BccFuba.Models;

namespace BccFuba.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(Message message);
    }
}
