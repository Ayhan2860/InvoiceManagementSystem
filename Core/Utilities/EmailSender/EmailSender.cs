

using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;
using MimeKit.Text;

namespace Core.Utilities.EmailSender
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions _emailOptions;
        public IConfiguration Configuration {get;}

        public EmailSender(IConfiguration configuration)
        {
             Configuration = configuration;
            _emailOptions = Configuration.GetSection("Smtp").Get<EmailOptions>();
        }

        public void SendEMail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);
            Send(emailMessage);
        }

       
        private MimeMessage CreateEmailMessage(Message message)
        {
            var content =  $"<h1 style='background:teal;text-align:center; color:white; padding: 10px 0; border-radius:10px'> Kullanıcı Parolanız İle Sisteme Giriş Yapabilirsiniz <br/> <br/>{message.Content}</h1>";
            var emailMessage = new MimeMessage();
            emailMessage.From.Add(MailboxAddress.Parse(_emailOptions.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(TextFormat.Html){Text = content};

            return emailMessage;
        }

         private void Send(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect(_emailOptions.SmtpServer, _emailOptions.Port, SecureSocketOptions.StartTls);
                    client.Authenticate(_emailOptions.From, _emailOptions.Password);
                    client.Send(emailMessage);
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
}