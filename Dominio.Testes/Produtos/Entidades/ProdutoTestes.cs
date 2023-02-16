using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Produtos.Entidades;
using FizzWare.NBuilder;
using FluentAssertions;
using Xunit;

namespace Dominio.Testes.Produtos.Entidades
{
    public class ProdutoTestes
    {
        private readonly Produto sut;

        public ProdutoTestes()
        {
            sut = Builder<Produto>.CreateNew().Build();
        }

        public class Construtor
        {
            [Fact]
            public void Quando_ParametrosForemValidos_Espero_ObjetoIntegro()
            {
                var produto = new Produto("abacaxi", 10m);
                produto.Nome.Should().Be("abacaxi");
                produto.Valor.Should().Be(10m);
                produto.Validade.Day.Should().Be(DateTime.Now.AddDays(7).Day);
            }
        }

        public class SetNomeMetodo : ProdutoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData(" ")]

            public void Dado_NomeNuloOuEspacoEmBranco_Espero_Excecao(string nome)
            {
                sut.Invoking(x => x.SetNome(nome)).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_NomeValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetNome("Carne");
                sut.Nome.Should().NotBeNullOrWhiteSpace();
                sut.Nome.Should().Be("Carne");
            }

        }

        public class SetValorMetodo : ProdutoTestes
        {
            [Theory]
            [InlineData(0)]
            [InlineData(-5)]
            public void Dado_ValorIgualOuMenorQueZero_Espero_Excecao(decimal valor)
            {
                sut.Invoking(x => x.SetValor(valor)).Should().Throw<Exception>();
            }

            [Fact]
            public void Dado_ValorValido_Espero_PropriedadesPreenchidas()
            {
                sut.SetValor(20m);
                sut.Valor.Should().BeGreaterThan(0);
                sut.Valor.Should().Be(20m);
            }
        }

    }
}