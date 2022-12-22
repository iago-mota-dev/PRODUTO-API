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
            if (String.IsNullOrWhiteSpace(nome))
            {
                throw new Exception("Nome não pode ser vazio ou nulo");
            }
            this.Nome = nome;
        }
        public virtual void SetValor(decimal valor)
        {
            if (valor <= 0)
            {
                throw new Exception("Valor não pode ser menor ou igual a zero");
            }
            this.Valor = valor;
        }
        public virtual void SetValidade()
        {
            this.Validade = DateTime.Now.AddDays(7);
        }
    }
}