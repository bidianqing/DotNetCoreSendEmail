using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            using (var message = new MailMessage())
            {
                message.To.Add("bidianqing@qq.com");
                message.From = new MailAddress("bidianqing123@163.com");
                message.To.Add("bidianqing@qq.com");
                message.Body = "body";
                message.Subject = "subject";
                message.IsBodyHtml = true;

                using (var client = new SmtpClient("smtp.163.com"))
                {
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("bidianqing123", "password");

                    client.Send(message);
                }
            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
