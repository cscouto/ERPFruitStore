using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Compra
{
    public partial class CompraDetailsPage : ContentPage
    {
        AppLoja.Model.Compra compra;
        public CompraDetailsPage(AppLoja.Model.Compra compra)
        {
            this.compra = compra;
            InitializeComponent();
            
            //definindo modelo para list
            lvProdutos.ItemTemplate = new DataTemplate(typeof(ProdutoNotaCell));

            using (var dados = new DataAccess())
            {
                compra.Produtos = dados.GetProdutoNotas().Where(c=> c.IdCompra == compra.IdCompra).ToList();
            }

            lbId.Text = compra.IdCompra.ToString();
            lbFornecedor.Text = compra.Fornecedor.Descricao.ToString();
            lvProdutos.ItemsSource = compra.GetProdutos();
            lbData.Text = compra.DataCompra;
            lbValorTotal.Text = compra.ValorTotal.ToString();

        }
    }
}
