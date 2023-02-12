using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Fornecedores.Entidades;

namespace Dominio.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresServico
    {
        Fornecedor Validar(int id);
        Fornecedor Instanciar(string nome, bool status, int mesesDoContrato);
        void Inserir(Fornecedor fornecedor);
        void Excluir(int id);
        void Atualizar(Fornecedor fornecedor, int id);
    }
}