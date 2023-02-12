using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTransfer.Fornecedores.Requests
{
    public class FornecedorRequest
    {
        public string Nome { get; set; }
        public bool Status { get; set; }
        public int MesesDoContrato { get; set; }
    }
}