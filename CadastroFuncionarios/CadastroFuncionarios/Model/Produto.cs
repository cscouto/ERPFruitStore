using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;

namespace AppLoja.Model
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int IdProduto { get; set; }

        public string Descricao { get; set; }
        public double Preco { get; set; }
        public string IconSource { get; set; }

        public override string ToString()
        {
            return this.Descricao;
        }
    }
    
}
