using AppCEP.servico;
using AppCEP.servico.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCEP
{
        [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            ImgLogo.Source = ImageSource.FromResource("AppCEP.img.Logo.png");
        }

        private void btnBuscar_Clicked(object sender, EventArgs e)
        {
            //retirar os espaços vazio do entry
            String cep = txtCEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServicos.BuscarEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereço: {2} \nBairro: {3} \nCidade: {0}-{1}", end.localidade, end.uf, end.logadouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO!", "O endereço não foi encontrado para o CEP informado: " + cep, "OK");
                    }
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
            }

        }
        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if(cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP invalido! O CEP deve conter 8 caracteres.", "OOK");
                valido = false;
            }
            int novoCEP = 0;
            if(!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("Erro", "CEP invalido! o CEP deve ser composto apenas por número.", "OK");
                valido = false;
            }
            return valido;

        }


    }
}
