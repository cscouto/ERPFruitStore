using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Produto
{
    public partial class CadastraProdutoPage : ContentPage
    {
        IList<string> Icons;
        public CadastraProdutoPage()
        {
            InitializeComponent();
            btCadastrar.Clicked += BtCadastrar_Clicked;

            Icons = new List<string>()
            {
                "apple.png","avocado.png", "strawberry.png", "banana.png", "blueberries.png", "cherries.png",
                "coconut.png", "kiwi.png", "default.png","grape.png", "lime.png", "orange.png", "pear.png", "pineapple",
                "raspberry.png", "watermelon.png"
            };

            foreach(string fruta in Icons)
            {
                ImagePicker.Items.Add(fruta);
            }

        }

        private async void BtCadastrar_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(EntryDescricao.Text))
            {
                await DisplayAlert("Error", "Preencha o Nome", "OK");
                EntryDescricao.Focus();
                return;
            }
            var produto = new AppLoja.Model.Produto()
            {
                Descricao = EntryDescricao.Text,
                Preco = Convert.ToDouble(EntryPreco.Text),
                IconSource = Icons[ImagePicker.SelectedIndex]
            };

            using (var dados = new DataAccess())
            {
                dados.InsertProduto(produto);
            }
            EntryDescricao.Text = string.Empty;
            EntryPreco.Text = string.Empty;
            ImagePicker.SelectedIndex = -1;
            await DisplayAlert("Mensagem", "Produto Cadastrado", "OK");
        }
    }
}
