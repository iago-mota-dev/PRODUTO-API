using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTransfer.Produtos.Requests
{
    public class ProdutoRequest
    {
        public string? Nome { get; set; }
        public decimal Valor { get; set; }
    }
}