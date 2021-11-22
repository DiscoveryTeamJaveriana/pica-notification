using ApplicationCore.DTO;
using MimeKit;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IEmailService
    {
        public Task<NotificationResponse> SendEmail(EmailMessage message);
        public Task<MimeMessage> CreateMimeMessageFromEmailMessage(EmailMessage message);
    }
}
