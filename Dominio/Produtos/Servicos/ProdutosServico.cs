using Dominio.Produtos.Entidades;
using Dominio.Produtos.Repositorios;
using Dominio.Produtos.Servicos.Interfaces;

namespace Dominio.Produtos.Servicos
{
    public class ProdutosServico : IProdutosServico
    {
        private readonly IProdutosRepositorio produtosRepositorio;
        public ProdutosServico(IProdutosRepositorio produtosRepositorio)
        {
            this.produtosRepositorio = produtosRepositorio;
        }

        public void Atualizar(string nome, decimal valor, int id)
        {
            Produto produtoAnterior = Validar(id);
            produtoAnterior.SetNome(nome);
            produtoAnterior.SetValor(valor);
            produtosRepositorio.Atualizar(produtoAnterior);
        }

        public void Excluir(int id)
        {
            Produto produto = Validar(id);
            produtosRepositorio.Excluir(produto);
        }

        public Produto InserirProduto(Produto produto)
        {
            var produtoResponse = produtosRepositorio.Inserir(produto);
            return produtoResponse;
        }

        public Produto Instanciar(string nome, decimal valor)
        {
            var produtoResponse = new Produto(nome, valor);
            return produtoResponse;
        }

        public Produto Validar(int id)
        {
            var produtoResponse = this.produtosRepositorio.Recuperar(id);
            if (produtoResponse is null)
            {
                throw new Exception("Produto não encontrado");
            }
            return produtoResponse;
        }
    }
}