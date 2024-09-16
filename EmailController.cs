using EmailExample.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EmailExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController()
        {
            _emailService = new EmailService();
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail()
        {
            string recipientEmail = "poojastee30@gmail.com";
            string subject = "Test Email with Embedded Image and Link";
            string imagePath = "c:/Users/HP/Desktop/download.png"; // Replace with the path to your image
            string htmlContent = @"
                <html>
                <body>
                    <h1 style='color:#3498db;'>Hello!</h1>
                    <p>Maybelin New York:</p>
                    <img src='cid:InlineImage' alt='Logo' />
                     <p>Visit our <a href='https://www.nykaa.com/brands/maybelline-new-york/c/596?ptype=brand&id=596&root=brand_menu,top_brands,Maybelline%20New%20York' style='color:#e74c3c; font-weight:bold; text-decoration:none;'>website</a> for more information.</p>
               
</body>
                </html>";



            await _emailService.SendEmailAsync(recipientEmail, subject, htmlContent, imagePath);

            return Ok("Email sent successfully!");
        }
    }
}
