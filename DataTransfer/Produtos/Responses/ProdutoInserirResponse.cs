using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTransfer.Produtos.Responses
{
    public class ProdutoInserirResponse
    {
        public string? Nome { get; set; }
        public decimal Valor { get; set; }
        public DateTime Validade { get; set; }
    }
}