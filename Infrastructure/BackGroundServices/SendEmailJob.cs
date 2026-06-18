using Application.Interfaces;
using Microsoft.Extensions.Caching.Distributed;

namespace Infrastructure.BackGroundServices;

public class SendEmailJob(IEmailService emailService)
{
    public async Task SendEmail()
    {
        var to = new string[]
        {
            "nekruzrashidov@gmail.com"
        };
        var subject = "Send Email";
        var body = "Hello World!";

        foreach (var s in to)
        {
            await emailService.SendEmailAsync(s, subject, body);
        }
    }
}
