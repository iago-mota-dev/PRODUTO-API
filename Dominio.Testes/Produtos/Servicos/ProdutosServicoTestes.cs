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
            produtoValido = Builder<Produto>.CreateNew().With(x => x.Valor, 123m).Build();
            var produtos = Builder<Produto>.CreateListOfSize(2).All().With(x => x.Valor, 123m).Build();

            produtosRepositorio = Substitute.For<IProdutosRepositorio>();
            sut = new ProdutosServico(produtosRepositorio);
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