using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLoja.Pages.Menu
{
    public class MenuPage : ContentPage
    {
        public ListView Menu { get; set; }

        public MenuPage()
        {
            Title = "menu";
            Icon = "ic_action_list.png";
            BackgroundColor = Color.Teal;

            Menu = new MenuListView();
            //Menu.SeparatorColor = Color.Teal;

            var menuLabel = new ContentView
            {
                Padding = new Thickness(10,26,0,5),
                Content = new Label
                {
                    TextColor = Color.White,
                    Text = "MENU",
                }
            };

            var layout = new StackLayout
            {
                Spacing = 5,
                Padding = 10,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            layout.Children.Add(menuLabel);
            layout.Children.Add(Menu);

            Content = layout;
        }
    }
}
