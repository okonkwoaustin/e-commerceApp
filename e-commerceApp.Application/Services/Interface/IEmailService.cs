
using e_commerceApp.Shared.Models.Email;

namespace e_commerceApp.Application.Services.Interface
{
    public interface IEmailService
    {
        void SendEmail(Message message);
    }
}
