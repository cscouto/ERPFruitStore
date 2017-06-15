using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoja.Model
{
    public class ProdutoVenda
    {
        [PrimaryKey, AutoIncrement]
        public int IdProdutoVenda { get; set; }

        [OneToOne]
        public Produto Produto { get; set; }

        [ForeignKey(typeof(Produto))]
        public int IdProduto { get; set; }

        public double Preco { get; set; }

        [ForeignKey(typeof(Venda))]
        public int IdVenda { get; set; }

        public int Quantidade { get; set; }

        [ManyToOne]
        public Venda Venda { get; set; }
    }
}
