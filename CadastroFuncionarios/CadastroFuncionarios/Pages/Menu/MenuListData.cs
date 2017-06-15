using AppLoja.Pages.Compra;
using AppLoja.Pages.Estoque;
using AppLoja.Pages.Fornecedor;
using AppLoja.Pages.Produto;
using AppLoja.Pages.Venda;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoja.Pages.Menu
{
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            this.Add(new MenuItem()
            { 

                Titulo = "Inicio",
                IconSource = "home.png",
                TargetType = typeof(HomePage)
            });
            this.Add(new MenuItem()
            {
                Titulo = "Produtos",
                IconSource = "fruit.png",
                TargetType = typeof(ProdutoListaPage)
            });
            this.Add(new MenuItem()
            {
                Titulo = "Fornecedores",
                IconSource = "supplier.png",
                TargetType = typeof(FornecedorListaPage)
            });
            this.Add(new MenuItem()
            {
                Titulo = "Compra",
                IconSource = "purchase.png",
                TargetType = typeof(CompraListaPage)
            });
            
            this.Add(new MenuItem()
            {
                Titulo = "Venda",
                IconSource = "trade.png",
                TargetType = typeof(VendaListaPage)
            });

            this.Add(new MenuItem()
            {
                Titulo = "Estoque",
                IconSource = "warehouse.png",
                TargetType = typeof(EstoquePage)
            });
        }
    }
}
