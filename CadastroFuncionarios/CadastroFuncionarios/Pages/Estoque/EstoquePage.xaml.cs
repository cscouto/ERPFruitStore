using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Estoque
{
    public partial class EstoquePage : ContentPage
    {
        public EstoquePage()
        {
            InitializeComponent();

            lvEstoque.ItemTemplate = new DataTemplate(typeof(EstoqueCell));

            using(var dados = new DataAccess())
            {
                lvEstoque.ItemsSource = dados.GetEstoques();
            }
        }
    }
}
