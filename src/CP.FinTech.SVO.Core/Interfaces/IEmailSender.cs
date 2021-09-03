using System.Threading.Tasks;

namespace CP.FinTech.SVO.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
