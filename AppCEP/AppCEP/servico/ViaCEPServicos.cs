using AppCEP.servico.Modelo;
using Newtonsoft.Json;
using System.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCEP.servico
{
    public class ViaCEPServicos
    {
        //string com o endereço do serviço web
        private static string EnderecoURL = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscarEnderecoViaCEP(string cep)
        {
            //propriedade estatica que recebe o endereço
            string NovoEnderecoURL = string.Format(EnderecoURL, cep);

            //objeto que acessa o resultado do endereço web passado como parametro
            WebClient wc = new WebClient();
            string Conteudo = wc.DownloadString(NovoEnderecoURL);

            //objeto do tipo Classe enderço que recebe os dados des-serializados
            Endereco end = JsonConvert.DeserializeObject<Endereco>(Conteudo);

            //Caso não haja retorno do serviço Web
            if (end.cep == null) return null;

            return end;


        }
    }
}
