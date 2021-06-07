using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace TermScheduler
{
    public static class ComposeEmail
    {
        public static async Task SendEmail(string subject, string body, List<string> recipients)
        {
            var message = new EmailMessage
            {
                Subject = subject,
                Body = body,
                To = recipients
            };

            await Email.ComposeAsync(message);
        }
    }
}
