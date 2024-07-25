using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using ShopAPI.Models;

namespace ShopAPI.Helper.Email
{
    public class EmailService
    {

        public void EmailSender(EmailData emailData)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailData.From));
            email.To.Add(MailboxAddress.Parse(emailData.To));
            email.Subject = emailData.Subject;
            email.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = emailData.Body };

            using var smtp = new SmtpClient();

            try
            {
                // Sertifika doğrulamasını devre dışı bırakmak yerine doğru sertifikayı kontrol edin
                smtp.ServerCertificateValidationCallback = (sender, certificate, chain, errors) => true;

                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(emailData.From, emailData.Password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (Exception ex)
            {
                // Hata yönetimi: Hata mesajını loglayın veya yönetin
                Console.WriteLine($"E-posta gönderme hatası: {ex.Message}");
            }
        }


    }
}
