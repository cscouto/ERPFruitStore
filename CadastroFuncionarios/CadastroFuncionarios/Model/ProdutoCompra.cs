using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoja.Model
{
    public class ProdutoCompra
    {
        [PrimaryKey , AutoIncrement]
        public int IdProdutoCompra { get; set; }

        [OneToOne]
         public Produto Produto { get; set; }

        [ForeignKey(typeof(Produto))]
        public int IdProduto { get; set; }

        public double Preco { get; set; }

        [ForeignKey(typeof(Compra))]
        public int IdCompra { get; set; }

        public int Quantidade { get; set; }

        [ManyToOne]
        public Compra Compra { get; set; }
    }
}
