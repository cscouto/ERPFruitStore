using AppLoja.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Produto
{
    public partial class EditPage : ContentPage
    {
        IList<string> Icons;
        private Model.Produto Produto;

        public EditPage(Model.Produto produto)
        {
            InitializeComponent();
            this.Produto = produto;

            btApagar.Clicked += btApagarClicked;
            btAtualizar.Clicked += btAtualizarClicked;

            Icons = new List<string>()
            {
                "apple.png","avocado.png", "strawberry.png", "banana.png", "blueberries.png", "cherries.png",
                "coconut.png", "kiwi.png", "default.png","grape.png", "lime.png", "orange.png", "pear.png", "pineapple",
                "raspberry.png", "watermelon.png"
            };

            foreach (string fruta in Icons)
            {
                ImagePicker.Items.Add(fruta);
            }
            //carrega com informacoes do funcionario na listview
            nomeEntry.Text = produto.Descricao;
            EntryPreco.Text = produto.Preco.ToString();
            ImagePicker.SelectedIndex = Icons.IndexOf(produto.IconSource);
        }

        public async void btAtualizarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nomeEntry.Text))
            {
                await DisplayAlert("Error", "Preencha o Nome", "OK");
                nomeEntry.Focus();
                return;
            }

            Model.Produto produto = new Model.Produto()
            {
                IdProduto = this.Produto.IdProduto,
                Descricao = nomeEntry.Text,
                Preco = Convert.ToDouble(EntryPreco.Text),
                IconSource = Icons[ImagePicker.SelectedIndex]
            };

            using (var dados = new DataAccess())
            {
                dados.UpdateProduto(produto);
            }

            await DisplayAlert("Confirmacao", "Produto Atualizado Corretamente", "OK");
            await Navigation.PopAsync();
        }

        public async void btApagarClicked(object sender, EventArgs e)
        {
            var confirm = await DisplayAlert("Confirmacao", "Deseja apagar o produto?", "Sim", "Nao");
            if (!confirm) return;

            using (var dados = new DataAccess())
            {
                dados.DeleteProduto(Produto);
            }

            await DisplayAlert("Confirmacao", "Produto Apagado Corretamente", "OK");
            await Navigation.PopAsync();
        }
    }
}
