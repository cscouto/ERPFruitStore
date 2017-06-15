using AppLoja.Pages.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLoja.Pages
{
    public class MainPage : MasterDetailPage
    {
        MenuPage menuPage;

        public MainPage()
        {
            menuPage = new MenuPage();

            menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as Menu.MenuItem);

            Master = menuPage;
            Detail = new NavigationPage(new HomePage());
        }

        async void NavigateTo(Menu.MenuItem menu)
        {
            if (menu == null)
                return;

            Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);

            try
            {
                Detail = new NavigationPage(displayPage);
            }catch(Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("ERRO", "Erro " + ex.Message, "OK");
            }

            menuPage.Menu.SelectedItem = null;
            IsPresented = false;
        }
    }
}
