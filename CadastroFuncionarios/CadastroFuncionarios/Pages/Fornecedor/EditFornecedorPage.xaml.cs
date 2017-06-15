using AppLoja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Fornecedor
{
    public partial class EditFornecedorPage : ContentPage
    {
        private AppLoja.Model.Fornecedor Fornecedor;

        public EditFornecedorPage(Model.Fornecedor Fornecedor)
        {
            InitializeComponent();
            this.Fornecedor = Fornecedor;

            btApagar.Clicked += btApagarClicked;
            btAtualizar.Clicked += btAtualizarClicked;

            //carrega com informacoes do funcionario na listview
            nomeEntry.Text = Fornecedor.Descricao;
            cnpjEntry.Text = Fornecedor.CNPJ;

        }

        public async void btAtualizarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nomeEntry.Text))
            {
                await DisplayAlert("Error", "Preencha o Nome", "OK");
                nomeEntry.Focus();
                return;
            }

            Model.Fornecedor Fornecedor = new Model.Fornecedor()
            {
                IdFornecedor = this.Fornecedor.IdFornecedor,
                Descricao = nomeEntry.Text,
                CNPJ = cnpjEntry.Text
            };

            using (var dados = new DataAccess())
            {
                dados.UpdateFornecedor(Fornecedor);
            }

            await DisplayAlert("Confirmacao", "Fornecedor Atualizado Corretamente", "OK");
            await Navigation.PopAsync();
        }

        public async void btApagarClicked(object sender, EventArgs e)
        {
            var confirm = await DisplayAlert("Confirmacao", "Deseja apagar o Fornecedor?", "Sim", "Nao");
            if (!confirm) return;

            using (var dados = new DataAccess())
            {
                dados.DeleteFornecedor(Fornecedor);
            }

            await DisplayAlert("Confirmacao", "Fornecedor Apagado Corretamente", "OK");
            await Navigation.PopAsync();
        }
    }
}

