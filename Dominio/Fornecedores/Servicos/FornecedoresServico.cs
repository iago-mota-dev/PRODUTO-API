using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Fornecedores.Entidades;
using Dominio.Fornecedores.Repositorios;
using Dominio.Fornecedores.Servicos.Interfaces;

namespace Dominio.Fornecedores.Servicos
{
    public class FornecedoresServico : IFornecedoresServico
    {
        private readonly IFornecedoresRepositorio fornecedoresRepositorio;

        public FornecedoresServico(IFornecedoresRepositorio fornecedoresRepositorio)
        {
            this.fornecedoresRepositorio = fornecedoresRepositorio;
        }

        public void Atualizar(Fornecedor fornecedor, int id)
        {
            Fornecedor fornecedorAnterior = Validar(id);

            fornecedorAnterior.SetNome(fornecedor.Nome);
            fornecedorAnterior.SetStatus(fornecedor.Status);
        }

        public void Excluir(int id)
        {
            this.fornecedoresRepositorio.Excluir(Validar(id));
        }

        public void Inserir(Fornecedor fornecedor)
        {
            fornecedoresRepositorio.Inserir(fornecedor);
        }

        public Fornecedor Instanciar(string nome, bool status, int mesesDoContrato)
        {
            return new Fornecedor(nome, status, mesesDoContrato);
        }

        public Fornecedor Validar(int id)
        {
            Fornecedor fornecedor = this.fornecedoresRepositorio.Recuperar(id);
            if (fornecedor is null)
            {
                throw new Exception("Fornecedor não existe");
            }
            return fornecedor;
        }
    }
}