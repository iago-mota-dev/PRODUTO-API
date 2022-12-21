using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataTransfer.Produtos.Requests;
using DataTransfer.Produtos.Responses;

namespace Aplicacao.Produtos.Servicos.Interfaces
{
    public interface IProdutosAppServico
    {
        ProdutoResponse Recuperar(int id);
        ProdutoInserirResponse InserirProduto(ProdutoInserirRequest produtoRequest);
    }
}