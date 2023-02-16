using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Utils
{
    public class Paginacao<T>
    {
        public int Qtd { get; set; }
        public IList<T> Registros { get; set; }
        public Paginacao(int qtd, IList<T> registros)
        {
            Qtd = qtd;
            Registros = registros;
        }
    }
}