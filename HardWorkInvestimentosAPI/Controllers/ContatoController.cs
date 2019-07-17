using System;
using System.Collections.Generic;
using System.Linq;
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
        public string EnviarEmail([FromBody] ContatoForm contatoForm)
        {
            if(contatoForm != null)
            {
                return JsonConvert.True;
            }
            return JsonConvert.False;
        }
    }
}