using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dominio.Produtos.Entidades
{
    public class Produto
    {
        public virtual int Id { get; protected set; }
        public virtual string? Nome { get; protected set; }
        public virtual decimal Valor { get; protected set; }
        public virtual DateTime Validade { get; protected set; }

        protected Produto() { }

        public Produto(string? nome, decimal valor)
        {
            SetNome(nome);
            SetValor(valor);
            SetValidade();
        }

        public virtual void SetNome(string? nome)
        {
            this.Nome = nome;
        }
        public virtual void SetValor(decimal valor)
        {
            this.Valor = valor;
        }
        public virtual void SetValidade()
        {
            this.Validade = DateTime.Now.AddDays(7);
        }
    }
}