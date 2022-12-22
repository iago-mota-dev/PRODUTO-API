using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Produtos.Entidades;
using Dominio.Produtos.Repositorios;
using Dominio.Produtos.Servicos;
using FizzWare.NBuilder;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace Dominio.Testes.Produtos.Servicos
{
    public class ProdutosServicoTestes
    {
        private readonly ProdutosServico sut;
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
                produtosRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);
                sut.Invoking(x => x.Validar(2)).Should().Throw<Exception>();

            }

            [Fact]
            public void Dado_ProdutoEncontrado_Espero_ProdutoValido()
            {
                produtosRepositorio.Recuperar(Arg.Any<int>()).Returns(produtoValido);
                sut.Validar(2).Should().BeSameAs(produtoValido);
            }
        }
        public class InstanciarMetodo: ProdutosServicoTestes{
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
        public class InserirMetodo: ProdutosServicoTestes{
            [Fact]
            public void Dado_ProdutoValido_Espero_ProdutoInserido(){
                produtosRepositorio.Inserir(Arg.Any<Produto>()).Returns(produtoValido);

                var produto = sut.InserirProduto(produtoValido);

                produtosRepositorio.Received(1).Inserir(produtoValido);
                produto.Should().BeOfType<Produto>();
                produto.Should().Be(produtoValido);
            }
        }
    }
}