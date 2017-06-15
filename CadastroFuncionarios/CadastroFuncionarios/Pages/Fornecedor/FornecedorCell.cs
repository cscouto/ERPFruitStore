using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppLoja.Pages.Fornecedor
{
    class FornecedorCell : ViewCell
    {
        public FornecedorCell()
        {
            var Icon = new Image
            {

            };
            Icon.Source = "businessman.png";

            var LbDescricao = new Label
            {
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                FontSize = 20
            };
            LbDescricao.SetBinding(Label.TextProperty, new Binding("Descricao"));

            View = new StackLayout
            {
                Children = { Icon, LbDescricao },
                Orientation = StackOrientation.Horizontal,
                VerticalOptions = LayoutOptions.Center,
                Padding = 5
            };
        }

    }
}
