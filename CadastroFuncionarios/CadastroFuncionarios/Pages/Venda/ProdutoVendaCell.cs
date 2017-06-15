using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLoja.Pages.Venda
{
    public class ProdutoVendaCell : ViewCell
    {
        public ProdutoVendaCell()
        {
            var Icon = new Image
            {
                HorizontalOptions = LayoutOptions.Start
            };
            Icon.SetBinding(Image.SourceProperty, new Binding("Produto.IconSource"));
            var LbProduto = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                VerticalOptions = LayoutOptions.Center
            };
            LbProduto.SetBinding(Label.TextProperty, new Binding("Produto.Descricao"));

            var LbInfo = new Label
            {
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center
            };
            LbInfo.Text = "Quantidade:";

            var LbValor = new Label
            {
                TextColor = Color.White,
                HorizontalOptions = LayoutOptions.End,
                VerticalOptions = LayoutOptions.Center
            };
            LbValor.SetBinding(Label.TextProperty, new Binding("Quantidade"));

            View = new StackLayout
            {
                Children = { Icon, LbProduto, LbInfo, LbValor },
                Orientation = StackOrientation.Horizontal,
                Padding = 5,
                //  BackgroundColor = Color.FromHex("#FFA500")
            };
        }
    }
}
