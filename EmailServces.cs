using System.Net.Mail;

        using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmailExample.Services
    {
        public class EmailService
        {
            public async Task SendEmailAsync(string recipientEmail, string subject, string htmlContent, string imagePath)
            {
                var email = new MailMessage
                {
                    From = new MailAddress("keerthisri1106@gmail.com"),
                    Subject = subject,
                    Body = htmlContent,
                    IsBodyHtml = true // Ensures the body is treated as HTML
                };

                email.To.Add(recipientEmail);

                // Embed image
                if (!string.IsNullOrEmpty(imagePath))
                {
                    var inlineLogo = new LinkedResource(imagePath)
                    {
                        ContentId = "InlineImage"
                    };
                    var htmlView = AlternateView.CreateAlternateViewFromString(htmlContent, null, "text/html");
                    htmlView.LinkedResources.Add(inlineLogo);
                    email.AlternateViews.Add(htmlView);
                }

                using (var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Credentials = new NetworkCredential("keerthisri1106@gmail.com", "sfuu jqew caal jzrq");
                    client.EnableSsl = true;
                    await client.SendMailAsync(email);
                }
            }
        }
    }


