using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoja.Model
{
    public class Compra
    {
        [PrimaryKey, AutoIncrement]
        public int IdCompra { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<ProdutoCompra> Produtos { get; set; }

        [OneToOne]
        public Fornecedor Fornecedor { get; set; }

        [ForeignKey(typeof(Fornecedor))]
        public int IdFornecedor { get; set; }

        public string DataCompra { get; set; }
        public double ValorTotal { get; set; }

        public Compra()
        {
            Produtos = new List<ProdutoCompra>();
        }

        public List<ProdutoCompra> GetProdutos()
        {
            return Produtos;
        }

    }

}
