using AppLoja.Model;
using AppLoja.Pages.Fornecedor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Fornecedor
{
    public partial class FornecedorListaPage : ContentPage
    {
        public FornecedorListaPage()
        {
            InitializeComponent();

            lvFornecedores.ItemSelected += LvProdutos_ItemSelected;

            //Define o template com a class FuncionarioCell
            lvFornecedores.ItemTemplate = new DataTemplate(typeof(FornecedorCell));

            btCadastrar.Clicked += BtCadastrar_Clicked;
            
        }

        private void BtCadastrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CadastraFornecedorPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //Acessa os dados atraves do DataAccess e preenche a lista
            using (var dados = new DataAccess())
            {
                lvFornecedores.ItemsSource = dados.GetFornecedors();
            }
        }
        private void LvProdutos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new FornecedorDetailsPage((Model.Fornecedor)e.SelectedItem));
        }
    }
}
