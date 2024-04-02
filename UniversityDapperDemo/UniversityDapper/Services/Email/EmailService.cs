using MailKit.Net.Smtp;
using MimeKit;

namespace UniversityDapper.Services.Email
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendMail(string recipientEmail, string recipientName, string subject, string body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(
                _configuration["Mailtrap:From"], 
                _configuration["Mailtrap:EmailFrom"]));
            
            message.To.Add(new MailboxAddress(recipientName,recipientEmail));
            
            message.Subject = subject;

            message.Body = new TextPart("plain") { Text = body };

            using (var client = new SmtpClient())
            {
                client.Connect(_configuration["Mailtrap:Host"],
                    int.Parse(_configuration["Mailtrap:Port"]),
                    false
                   );


                client.Authenticate(_configuration["Mailtrap:Username"],
                    _configuration["Mailtrap:Password"]
                   );

                client.Send(message);
                client.Disconnect(true);
            }
        }

    }
}
