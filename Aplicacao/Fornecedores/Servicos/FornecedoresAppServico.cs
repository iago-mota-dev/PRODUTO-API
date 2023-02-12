using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Fornecedores.Servicos.Interfaces;
using AutoMapper;
using DataTransfer.Fornecedores.Requests;
using DataTransfer.Fornecedores.Responses;
using Dominio.Fornecedores.Entidades;
using Dominio.Fornecedores.Servicos.Interfaces;
using NHibernate;

namespace Aplicacao.Fornecedores.Servicos
{
    public class FornecedoresAppServico : IFornecedoresAppServico
    {
        private readonly IMapper mapper;
        private readonly ISession session;
        private readonly IFornecedoresServico fornecedoresServico;

        public FornecedoresAppServico(IMapper mapper, ISession session, IFornecedoresServico fornecedoresServico)
        {
            this.mapper = mapper;
            this.session = session;
            this.fornecedoresServico = fornecedoresServico;
        }

        public void Atualizar(FornecedorRequest request, int id)
        {
            var transacao = session.BeginTransaction();
            try
            {
                Fornecedor fornecedor = fornecedoresServico.Instanciar(request.Nome, request.Status, request.MesesDoContrato);

                fornecedoresServico.Atualizar(fornecedor, id);

                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
        }

        public void Excluir(int id)
        {
            fornecedoresServico.Excluir(id);
        }

        public void Inserir(FornecedorRequest request)
        {
            var transacao = session.BeginTransaction();
            try
            {
                Fornecedor fornecedor = fornecedoresServico.Instanciar(request.Nome, request.Status, request.MesesDoContrato);

                fornecedoresServico.Inserir(fornecedor);

                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
        }

        public FornecedorResponse Recuperar(int id)
        {
            Fornecedor fornecedor = fornecedoresServico.Validar(id);

            return mapper.Map<FornecedorResponse>(fornecedor);
        }
    }
}