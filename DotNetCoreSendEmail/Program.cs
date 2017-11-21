using System;
using System.Net;
using System.Net.Mail;

namespace DotNetCoreSendEmail
{
    class Program
    {
        static void Main(string[] args)
        {
            SmtpClient client = new SmtpClient("smtp.163.com");
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("bidianqing123", "your password");

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress("bidianqing123@163.com");
            mailMessage.To.Add("bidianqing@qq.com");
            mailMessage.Body = "body";
            mailMessage.Subject = "subject";
            client.Send(mailMessage);
            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}
