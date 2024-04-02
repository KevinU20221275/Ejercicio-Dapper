namespace UniversityDapper.Services.Email
{
    public interface IEmailService
    {
        void SendMail(string recipientEmail, string recipientName, string subject, string body);
    }
}
