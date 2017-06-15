using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLoja.Pages.Venda
{
    public class VendaCell : ViewCell
    {
        public VendaCell()
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
            LbInfo.Text = "Data Venda:";

            var LbIdVenda = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start
            };
            LbIdVenda.SetBinding(Label.TextProperty, new Binding("IdVenda"));

            var LbData = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.Start
            };
            LbData.SetBinding(Label.TextProperty, new Binding("DataVenda"));

            var panel1 = new StackLayout
            {
                Children = { LbCod, LbIdVenda },
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
