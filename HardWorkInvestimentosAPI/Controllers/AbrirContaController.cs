using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using HardWorkInvestimentosAPI.Models.AbrirConta;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HardWorkInvestimentosAPI.Controllers
{
    [EnableCors("AllowAllHeaders")]
    [Route("api/[controller]")]
    [ApiController]
    public class AbrirContaController : ControllerBase
    {
        // POST api/contato
        [HttpPost("EnviarEmail")]
        public async Task<string> EnviarEmail([FromBody] AbrirContaForm abrirContaForm)
        {
            var result = JsonConvert.False;
            try
            {
                var body = GetEmailBody(abrirContaForm);
                var message = new MailMessage();
                message.To.Add(new MailAddress("investimentos@hardworkbr.com.br"));  // replace with valid value 
                //message.To.Add(new MailAddress("allansouzab@hotmail.com"));  // replace with valid value 
                message.From = new MailAddress("WebsiteHardWork@hotmail.com");  // replace with valid value
                message.Subject = "Hard Work Investimentos - Abertura de conta";
                message.Body = body;
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


        public string GetEmailBody(AbrirContaForm model)
        {
            return string.Format($"" +
            $"<p><h2>Abertura de Conta</h2></p>" +
            "<p><h3>Dados do Cliente:</h3></p>" +
            $"<b>Nome:</b> {model.Nome}<br>" +
            $"<b>Celular:</b> {Convert.ToUInt64(model.Celular).ToString(@"\(00\) 00000\-0000")}<br>" +
            $"<b>Email:</b> {model.Email}<br>" +
            $"<b>RG:</b> {Convert.ToUInt64(model.Rg).ToString(@"00\.000\.000\-0")}<br>" +
            $"<b>Data de Expedição:</b> {model.DataExpedicao.ToShortDateString()}<br>" +
            $"<b>CPF:</b> {Convert.ToUInt64(model.Cpf).ToString(@"000\.000\.000\-00")}<br>" +
            $"<b>Data de Nascimento:</b> {model.DataNascimento.ToShortDateString()}<br>" +
            $"<b>Endereço:</b> {model.Endereco}<br>" +
            $"<b>Nº:</b> {model.Numero}<br>" +
            $"<b>Cidade:</b> {model.Cidade}<br>" +
            $"<b>Estado:</b> {model.Estado}<br>" +
            $"<b>CEP:</b> {Convert.ToUInt64(model.Cep).ToString(@"00000\-000")}<br>" +
            $"<b>Complemento:</b> {model.Complemento}<br>" +
            $"<b>Nome da mãe:</b> {model.NomeMae}<br>" +
            $"<b>Nome do cônjuge:</b> {model.NomeConjuge}<br>" +
            $"<b>Estado civil:</b> {model.EstadoCivil}<br>" +
            $"<b>Profissão:</b> {model.Profissao}<br>" +
            $"<b>Renda mensal:</b>{string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", model.RendaMensal)}<br>" +
            $"<b>Patrimônio total:</b>{string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", model.PatrimonioTotal)}<br>");
        }


    }
}