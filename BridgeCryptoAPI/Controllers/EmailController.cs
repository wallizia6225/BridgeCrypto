using BridgeCryptoAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mail;
using System.Net;

namespace BridgeCryptoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendEmail([FromForm] FormData formData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await SendFormData(formData);
                return Ok("Email sent successfully");
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private async Task SendFormData(FormData formData)
        {
            string emailBody = $"Business/Personal Name: {formData.BusinessNameOrPersonalName}\n" +
                               $"Industry: {formData.Industry}\n" +
                               $"Address Line1: {formData.AddressLine1}\n" +
                               $"Address Line2: {formData.AddressLine2 ?? "N/A"}\n" +
                               $"City/Municipality: {formData.City}\n" +
                               $"State/Province: {formData.State}\n" +
                               $"Country: {formData.Country}\n" +
                               $"Postal Code: {formData.PostalCode}\n" +
                               $"Phone: {formData.Phone}\n" +
                               $"Email Address: {formData.EmailAddress}\n" +
                               $"Website: {formData.Website}\n" +
                               $"Social Profile: {formData.SocialProfile ?? "N/A"}\n" +
                               $"First Name: {formData.FirstName}\n" +
                               $"Last Name: {formData.LastName}\n" +
                               $"Date Of Birth: {formData.DateOfBirth}\n";
            
            MailMessage mail = new MailMessage();

            // Here you can use any email service provider like SMTP or SendGrid
            var smtpClient = new SmtpClient("smtp.example.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("your-email@example.com", "your-password"),
                UseDefaultCredentials = Convert.ToBoolean(""),
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("your-email@example.com"),
                Subject = "Form Submission",
                Body = emailBody,
            };

            // Attach files
            mailMessage.Attachments.Add(new Attachment(formData.DriverLicense.OpenReadStream(), formData.DriverLicense.FileName));
            mailMessage.Attachments.Add(new Attachment(formData.SecondFileToUpload.OpenReadStream(), formData.SecondFileToUpload.FileName));
            mailMessage.Attachments.Add(new Attachment(formData.ProofOfAddress.OpenReadStream(), formData.ProofOfAddress.FileName));

            mailMessage.To.Add("recipient@example.com");

            await smtpClient.SendMailAsync(mailMessage);
        }

    }
}