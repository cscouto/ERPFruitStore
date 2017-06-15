using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoja.Model
{
    public class Estoque
    {
        [PrimaryKey, AutoIncrement]
        public int IdEstoque { get; set; }

        [OneToOne]
        public Produto Produto { get; set; }

        [ForeignKey(typeof(Produto))]
        public int IdProduto { get; set; }

        public int Quantidade { get; set; }
    }
}
