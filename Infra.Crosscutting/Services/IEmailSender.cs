using System.Threading.Tasks;

namespace Infra.Crosscutting.Services
{
    public interface IEmailSender
    {
        public Task SendMail(string email, string subject, string body);
    }
}
