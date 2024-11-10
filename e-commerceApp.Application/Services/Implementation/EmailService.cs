using e_commerceApp.Application.Services.Interface;
using e_commerceApp.Shared.Models.Email;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerceApp.Application.Services.Implementation
{
    public class EmailService : IEmailService
    {
        private readonly EmailConfiguration _config;

        public EmailService(EmailConfiguration config)
        {
            _config = config;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress("email", _config.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = message.Content };

            return emailMessage;
        }

        private void Send(MimeMessage message)
        {
            using var client = new SmtpClient();
            try
            {
                client.Connect(_config.SmtpServer, _config.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_config.UserName, _config.Password);

                client.Send(message);
            }
            catch
            {
                throw;
            }
            finally
            {
                client.Disconnect(true);
                client.Dispose();
            }
        }
    }
}
