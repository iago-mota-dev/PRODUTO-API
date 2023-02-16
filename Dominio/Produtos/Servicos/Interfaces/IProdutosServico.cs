using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Produtos.Entidades;

namespace Dominio.Produtos.Servicos.Interfaces
{
    public interface IProdutosServico
    {
        Produto Validar(int id);
        Produto InserirProduto(Produto produto);
        Produto Instanciar(string nome, decimal valor);
        void Excluir(int id);
        void Atualizar(string nome, decimal valor, int id);
    }
}