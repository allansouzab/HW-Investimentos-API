using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using HardWorkInvestimentosAPI.Models.Contato;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HardWorkInvestimentosAPI.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : ControllerBase
    {
        // POST api/contato
        [HttpPost("EnviarEmail")]
        public async Task<string> EnviarEmail([FromBody] ContatoForm contatoForm)
        {
            var result = JsonConvert.False;
            try
            {
                var body = "<p>Email de: {0} ({1})</p><p>Celular: {2}</p><p>Mensagem: {3}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("investimentos@hardworkbr.com.br"));  // replace with valid value 
                //message.To.Add(new MailAddress("allansouzab@hotmail.com"));  // replace with valid value 
                message.From = new MailAddress("WebsiteHardWork@hotmail.com");  // replace with valid value
                message.Subject = "Hard Work Investimentos - Contato";
                message.Body = string.Format(body, contatoForm.Nome, contatoForm.Email, Convert.ToUInt64(contatoForm.Celular).ToString(@"\(00\) 00000\-0000"), contatoForm.Mensagem);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    var credential = new NetworkCredential
                    {
                        UserName = "WebsiteHardWork@hotmail.com",  // replace with valid value
                        Password = "All@n1souza2"  // replace with valid value
                    };
                    smtp.Host = "smtp.live.com";
                    smtp.Port = 587;
                    smtp.EnableSsl = true;
                    smtp.Credentials = credential;
                    await smtp.SendMailAsync(message);

                    result = JsonConvert.True;
                }
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}