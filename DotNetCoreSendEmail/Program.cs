using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Net;
//using System.Net.Mail;

namespace DotNetCoreSendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            SmtpClient client = new SmtpClient("smtp.163.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("bidianqing123", "****");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("bidianqing123@163.com");
            mailMessage.To.Add("bidianqing@qq.com");
            mailMessage.Body = "body";
            mailMessage.Subject = "subject";
            client.Send(mailMessage);
            //*/

            // Use MailKit
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("毕殿卿","bidianqing123@163.com"));
            message.To.Add(new MailboxAddress("bidianqing","bidianqing@qq.com"));
            message.Subject = "Test";
            message.Body = new TextPart("plain")
            {
                Text = "测试"
            };

            using (var client = new SmtpClient())
            {
                // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;

                client.Connect("smtp.163.com", 25, false);

                // Note: only needed if the SMTP server requires authentication
                client.Authenticate("bidianqing123", "****");

                client.Send(message);
                client.Disconnect(true);
            }
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
