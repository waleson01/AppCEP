using System;
using System.Collections.Generic;
using System.Text;

namespace AppCEP.servico.Modelo
{
    public class Endereco
    {
        public string cep { get; set; }
        public string logadouro { get; set; }
        public string complemento { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string unidade { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }

    }
}
