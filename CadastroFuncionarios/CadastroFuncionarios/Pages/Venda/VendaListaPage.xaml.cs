using AppLoja.Pages.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Venda
{
    public partial class VendaListaPage : ContentPage
    {
        public VendaListaPage()
        {
            InitializeComponent();

            lvVendas.ItemSelected += LvVendas_ItemSelected;

            lvVendas.ItemTemplate = new DataTemplate(typeof(VendaCell));

            btCadastrar.Clicked += BtCadastrar_Clicked;
        }

        private void BtCadastrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new VendaPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lvVendas.ItemsSource = null;

            using (var dados = new DataAccess())
            {
                lvVendas.ItemsSource = dados.GetVendas();
            }
        }

        private void LvVendas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                Navigation.PushAsync(new VendaDetailsPage((Model.Venda)e.SelectedItem));
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
