using Microsoft.Extensions.Configuration;
using MimeKit;
using MyChannel.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyChannel.Infra.helpers
{
    public class EmailService
    {
        private readonly IConfiguration configuration;

        public EmailService(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public void SendEmail(EmailModel emailModel)
        {
            var EmailMsg = new MimeMessage();
            var From = configuration["EmailSettings:From"];
            EmailMsg.From.Add(new MailboxAddress("ChannelsProject", From));
            EmailMsg.To.Add(new MailboxAddress(emailModel.TO, emailModel.TO));
            EmailMsg.Subject = emailModel.Subject;
            EmailMsg.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = string.Format(emailModel.Content)
            };

            using (var Client = new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    Client.Connect(configuration["EmailSettings:SmtpServer"], 465, true);
                    Client.Authenticate(configuration["EmailSettings:From"],
                        configuration["EmailSettings:Password"]);
                    Client.Send(EmailMsg);

                }
                catch (Exception Ex)
                {
                    throw;
                }
                finally
                {
                    Client.Disconnect(true);
                    Client.Dispose();
                }
            }
        }
    }
}
