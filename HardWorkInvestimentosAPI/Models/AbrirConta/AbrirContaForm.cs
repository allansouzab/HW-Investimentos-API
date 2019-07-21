using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HardWorkInvestimentosAPI.Models.AbrirConta
{
    public class AbrirContaForm
    {
        public string Nome { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Rg { get; set; }
        public DateTime DataExpedicao { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public string Numero { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
        public string Complemento { get; set; }
        public string NomeMae { get; set; }
        public string NomeConjuge { get; set; }
        public string EstadoCivil { get; set; }
        public string Profissao { get; set; }
        public double RendaMensal { get; set; }
        public double PatrimonioTotal { get; set; }
    }
}
