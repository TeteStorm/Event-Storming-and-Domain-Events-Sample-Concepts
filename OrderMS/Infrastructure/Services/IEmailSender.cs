using System.Threading.Tasks;

namespace OrderMS.Infrastructure.Services
{
    public interface IEmailSender
    {
        public Task SendMail(string email, string subject, string body);
    }
}
