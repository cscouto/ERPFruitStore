using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages.Fornecedor
{
    public partial class FornecedorDetailsPage : ContentPage
    {
        AppLoja.Model.Fornecedor fornecedor;
        public FornecedorDetailsPage(AppLoja.Model.Fornecedor fornecedor)
        {
            this.fornecedor = fornecedor;
            InitializeComponent();

            lbName.Text = fornecedor.Descricao;
            lbId.Text = fornecedor.IdFornecedor.ToString();
            lbCnpj.Text = fornecedor.CNPJ;

            btEdit.Clicked += BtEdit_Clicked;
        }

        private void BtEdit_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
            Navigation.PushAsync(new EditFornecedorPage(fornecedor));
        }
    }
}
