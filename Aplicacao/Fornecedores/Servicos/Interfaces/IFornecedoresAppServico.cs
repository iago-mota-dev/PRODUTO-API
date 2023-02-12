using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Fornecedores.Requests;
using DataTransfer.Fornecedores.Responses;

namespace Aplicacao.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresAppServico
    {
        FornecedorResponse Recuperar(int id);
        void Inserir(FornecedorRequest request);
        void Atualizar(FornecedorRequest request, int id);
        void Excluir(int id);
    }
}