using AppLoja.Model;
using AppLoja.Pages.Produto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Produto
{
    public partial class ProdutoListaPage : ContentPage
    {
        public ProdutoListaPage()
        {
            InitializeComponent();

            lvProdutos.ItemSelected += LvProdutos_ItemSelected;
            
            //Define o template com a class FuncionarioCell
            lvProdutos.ItemTemplate = new DataTemplate(typeof(ProdutoCell));

            btCadastrar.Clicked += BtCadastrar_Clicked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            //Acessa os dados atraves do DataAccess e preenche a lista
            using (var dados = new DataAccess())
            {
                lvProdutos.ItemsSource = dados.GetProdutos();
            }
        }

        private void BtCadastrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastraProdutoPage());
        }

        private void LvProdutos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new ProdutoDetailsPage((Model.Produto)e.SelectedItem));
        }
    }

}
