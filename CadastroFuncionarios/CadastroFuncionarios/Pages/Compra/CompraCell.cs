using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLoja.Pages.Compra
{
    public class CompraCell : ViewCell
    {
        public CompraCell()
        {
            var LbCod = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start
            };
            LbCod.Text = "Cod:";

            var LbInfo = new Label
            {
                TextColor = Color.White,
            };
            LbInfo.Text = "Data Compra:";

            var LbIdCompra = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start
            };
            LbIdCompra.SetBinding(Label.TextProperty, new Binding("IdCompra"));

            var LbData = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start
            };
            LbData.SetBinding(Label.TextProperty, new Binding("DataCompra"));

            var panel1 = new StackLayout
            {
                Children = { LbCod, LbIdCompra },
                Orientation = StackOrientation.Horizontal
            };
            var panel2 = new StackLayout
            {
                Children = { LbInfo, LbData },
                Orientation = StackOrientation.Horizontal
            };
            View = new StackLayout
            {
                Children = { panel1, panel2 },
                Orientation = StackOrientation.Vertical,
                VerticalOptions = LayoutOptions.Fill,
            };
        }
    }
}
