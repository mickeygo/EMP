using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DotPlatform.Net.Mail
{
    public class MailSender : IMailSender
    {
        public void Send(string[] to, string[] cc, string[] bcc, string subject, string body, IDictionary<string, Stream> attachment, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
        }

        public void Send(string[] to, string[] cc, string[] bcc, string subject, string body, string[] attachment, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(string[] to, string[] cc, string[] bcc, string subject, string body, IDictionary<string, Stream> attachment, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
        }

        public Task SendAsync(string[] to, string[] cc, string[] bcc, string subject, string body, string[] attachment, bool isBodyHtml = true)
        {
            throw new NotImplementedException();
        }

        // Todo: Implement the Mail
    }
}
