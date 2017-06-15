using AppLoja.Pages.Compra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Compra
{
    public partial class CompraListaPage : ContentPage
    {
        public CompraListaPage()
        {
            InitializeComponent();

            lvCompras.ItemSelected += LvCompras_ItemSelected;

            lvCompras.ItemTemplate = new DataTemplate(typeof(CompraCell));

            btCadastrar.Clicked += BtCadastrar_Clicked;
        }

        private void BtCadastrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new CompraPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            lvCompras.ItemsSource = null;

            using (var dados = new DataAccess())
            {
                lvCompras.ItemsSource = dados.GetCompras();
            }
        }

        private void LvCompras_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                Navigation.PushAsync(new CompraDetailsPage((Model.Compra)e.SelectedItem));
            }catch(Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "OK");
            }
        }
    }
}
