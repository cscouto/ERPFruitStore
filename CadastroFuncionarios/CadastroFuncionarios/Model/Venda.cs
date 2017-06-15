using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoja.Model
{
    public class Venda
    {
        [PrimaryKey, AutoIncrement]
        public int IdVenda { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<ProdutoVenda> Produtos { get; set; }

        public string DataVenda { get; set; }
        public double ValorTotal { get; set; }

        public Venda()
        {
            Produtos = new List<ProdutoVenda>();
        }

        public List<ProdutoVenda> GetProdutos()
        {
            return Produtos;
        }
    }
}
