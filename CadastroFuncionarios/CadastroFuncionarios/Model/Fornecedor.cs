using SQLite.Net.Attributes;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLoja.Model
{
    public class Fornecedor
    {
        [PrimaryKey, AutoIncrement]
        public int IdFornecedor { get; set; }

        public string Descricao { get; set; }
        public string CNPJ { get; set; }

        public override string ToString()
        {
            return this.Descricao;
        }
    }
}
