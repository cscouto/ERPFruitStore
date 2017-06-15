using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Fornecedor
{
    public partial class CadastraFornecedorPage : ContentPage
    {
        public CadastraFornecedorPage()
        {
            InitializeComponent();
            btCadastrar.Clicked += BtCadastrar_Clicked;
        }

        private async void BtCadastrar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntryDescricao.Text))
            {
                await DisplayAlert("Error", "Preencha o Nome", "OK");
                EntryDescricao.Focus();
                return;
            }
            var fornecedor = new AppLoja.Model.Fornecedor()
            {
                Descricao = EntryDescricao.Text,
                CNPJ =  EntryCNPJ.Text
            };

            using (var dados = new DataAccess())
            {
                dados.InsertFornecedor(fornecedor);
            }
            EntryDescricao.Text = string.Empty;
            EntryCNPJ.Text = string.Empty;
            await DisplayAlert("Mensagem", "Fornecedor Cadastrado", "OK");
        }
    }
}
