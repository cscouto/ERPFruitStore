using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Venda
{
    public partial class VendaDetailsPage : ContentPage
    {
        AppLoja.Model.Venda Venda;
        public VendaDetailsPage(AppLoja.Model.Venda Venda)
        {
            this.Venda = Venda;
            InitializeComponent();

            //definindo modelo para list
            lvProdutos.ItemTemplate = new DataTemplate(typeof(AppLoja.Pages.Venda.ProdutoVendaCell));

            using (var dados = new DataAccess())
            {
                Venda.Produtos = dados.GetProdutoVendas().Where(c => c.IdVenda == Venda.IdVenda).ToList();
            }

            lbId.Text = Venda.IdVenda.ToString();
            lvProdutos.ItemsSource = Venda.GetProdutos();
            lbData.Text = Venda.DataVenda;
            lbValorTotal.Text = Venda.ValorTotal.ToString();


        }
    }
}
