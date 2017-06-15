using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace AppLoja.Pages
{
    public partial class Financas : ContentPage
    {
        double TotalCompras = 0;
        double TotalVendas = 0;
        double SaldoAtual = 0;
        double LucroAtual = 0;
        double VendaEmEstoque = 0;
        double CompraEmEstoque = 0;
        double SaldoEstoque = 0;
        double LucroPrevistoEstoque = 0;
        double LucroTotalPrevisto = 0;

        public Financas()
        {
            InitializeComponent();

            using(var dados = new DataAccess())
            {
                foreach(var compra in dados.GetCompras())
                {
                    TotalCompras += compra.ValorTotal;
                }
                foreach (var venda in dados.GetVendas())
                {
                    TotalVendas += venda.ValorTotal;
                }

                SaldoAtual = TotalVendas - TotalCompras;

            }
        }
    }
}
