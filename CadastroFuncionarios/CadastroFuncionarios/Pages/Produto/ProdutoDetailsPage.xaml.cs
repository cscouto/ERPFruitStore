using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLoja.Model;

using Xamarin.Forms;

namespace AppLoja.Pages.Produto
{
    public partial class ProdutoDetailsPage : ContentPage
    {
        AppLoja.Model.Produto produto;
        public ProdutoDetailsPage(AppLoja.Model.Produto produto)
        {
            this.produto = produto;
            InitializeComponent();

            ImageIcon.Source = produto.IconSource;
            lbName.Text = produto.Descricao;
            lbId.Text = produto.IdProduto+"";
            lbPreco.Text = produto.Preco+"";

            btEdit.Clicked += BtEdit_Clicked;
        }

        private void BtEdit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new EditPage(this.produto));
        }
    }
}
