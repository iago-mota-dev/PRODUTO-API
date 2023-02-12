using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataTransfer.Fornecedores.Responses
{
    public class FornecedorResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Status { get; set; }
        public DateTime ValidadeContratual { get; set; }
    }
}