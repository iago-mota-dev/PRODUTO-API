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
            Produto produto = Validar(id);
            produto.SetNome(nome);
            produto.SetValor(valor);
            produtosRepositorio.Atualizar(produto);
        }

        public void Excluir(int id)
        {
            Produto produto = Validar(id);
            produtosRepositorio.Excluir(produto);
        }

        public Produto InserirProduto(Produto produto)
        {
            produtosRepositorio.Inserir(produto);
            return produto;
        }

        public Produto Instanciar(string nome, decimal valor)
        {
            var produto = new Produto(nome, valor);
            return produto;
        }

        public Produto Validar(int id)
        {
            var produto = produtosRepositorio.Recuperar(id);
            if (produto is null)
            {
                throw new Exception("Produto não encontrado");
            }
            return produto;
        }
    }
}