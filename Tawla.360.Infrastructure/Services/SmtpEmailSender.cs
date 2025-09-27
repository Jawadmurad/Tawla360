using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Tawla._360.Infrastructure.Services;

public class SmtpEmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public SmtpEmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendEmailAsync(string email, string subject, string htmlMessage)
    {
        var smtpSection = _configuration.GetSection("SmtpSettings");

        var smtpClient = new SmtpClient(smtpSection["Host"], int.Parse(smtpSection["Port"]))
        {
            Credentials = new NetworkCredential(smtpSection["Username"], smtpSection["Password"]),
            EnableSsl = bool.Parse(smtpSection["EnableSsl"] ?? "true")
        };

        var mailMessage = new MailMessage
        {
            From = new MailAddress(smtpSection["From"]),
            Subject = subject,
            Body = htmlMessage,
            IsBodyHtml = true
        };
        mailMessage.To.Add(email);
        await smtpClient.SendMailAsync(mailMessage);
    }
}
