using Dominio.Produtos.Entidades;
using Dominio.Produtos.Repositorios;
using Dominio.Produtos.Servicos;
using Dominio.Produtos.Servicos.Interfaces;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using Xunit;

namespace Dominio.Testes.Produtos.Servicos
{
    public class ProdutosServicoTestes
    {
        private readonly IProdutosServico sut;
        private readonly Produto produtoValido;
        private readonly IProdutosRepositorio produtosRepositorio;

        public ProdutosServicoTestes()
        {
            produtoValido = Builder<Produto>.CreateNew().Build();
            produtosRepositorio = Substitute.For<IProdutosRepositorio>();
            sut = new ProdutosServico(produtosRepositorio);
        }

        public class ValidarMetodo : ProdutosServicoTestes
        {
            [Fact]
            public void Dado_ProdutoNaoEncontrado_Espero_Excecao()
            {
                const int ID_PRODUTO = 2;
                produtosRepositorio.Recuperar(ID_PRODUTO).ReturnsNull();
                sut.Invoking(x => x.Validar(ID_PRODUTO)).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_ProdutoEncontrado_Espero_ProdutoValido()
            {
                const int ID_PRODUTO = 2;
                produtosRepositorio.Recuperar(ID_PRODUTO).Returns(produtoValido);
                sut.Validar(ID_PRODUTO).Should().BeSameAs(produtoValido);
            }
        }
        public class InstanciarMetodo : ProdutosServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaCriarProduto_Espero_ProdutoInstanciado()
            {
                string nome = "frango";
                decimal valor = 20m;
                var produto = sut.Instanciar(nome, valor);

                produto.Should().NotBeNull();
                produto.Nome.Should().Be(nome);
                produto.Valor.Should().Be(valor);
                produto.Validade.Should().BeSameDateAs(DateTime.Now.AddDays(7));
            }
        }
        public class InserirMetodo : ProdutosServicoTestes
        {
            [Fact]
            public void Dado_ProdutoValido_Espero_ProdutoInserido()
            {
                Produto produto = Builder<Produto>.CreateNew().With(x => x.Nome, "Inserir").Build();
                Produto produtoInserido = sut.InserirProduto(produto);

                produtosRepositorio.Received().Inserir(produto);
                produtoInserido.Nome.Should().Be(produto.Nome);
            }
        }

        public class AtualizarMetodo : ProdutosServicoTestes
        {
            [Fact]
            public void Quando_MetodoForChamado_Espero_ProdutoAtualizado()
            {
                produtosRepositorio.Recuperar(1).Returns(produtoValido);

                sut.Atualizar("nome", 123m, 1);

                produtoValido.Nome.Should().Be("nome");
                produtoValido.Valor.Should().Be(123m);
                produtosRepositorio.Received().Atualizar(produtoValido);
            }
        }
        public class ExcluirMetodo : ProdutosServicoTestes
        {
            [Fact]
            public void Quando_MetodoForChamado_Espero_ProdutoDeletado()
            {
                produtosRepositorio.Recuperar(1).Returns(produtoValido);

                sut.Excluir(1);

                produtosRepositorio.Received().Excluir(produtoValido);
            }
        }
    }
}