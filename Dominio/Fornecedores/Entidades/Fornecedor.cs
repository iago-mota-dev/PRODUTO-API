using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Produtos.Entidades;

namespace Dominio.Fornecedores.Entidades
{
    public class Fornecedor
    {
        public virtual int Id { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual bool Status { get; protected set; }
        public virtual DateTime ValidadeContratual { get; protected set; }
        public virtual IList<Produto> Produtos { get; protected set; }

        public Fornecedor(string nome, bool status, int mesesDoContrato)
        {

            SetNome(nome);
            SetStatus(status);
            SetValidadeContratual(mesesDoContrato);
        }
        public virtual void SetNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new Exception("Nome é nulo");

            if (nome.Length > 255)
                throw new Exception("Nome é muito grande");

            Nome = nome;
        }

        public virtual void SetStatus(bool status)
        {
            Status = status;
        }
        public virtual void SetValidadeContratual(int mesesDoContrato)
        {
            ValidadeContratual = DateTime.Now.AddMonths(mesesDoContrato);
        }

    }
}