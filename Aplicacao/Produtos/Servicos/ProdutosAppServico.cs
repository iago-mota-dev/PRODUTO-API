using Aplicacao.Produtos.Servicos.Interfaces;
using AutoMapper;
using DataTransfer.Produtos.Requests;
using DataTransfer.Produtos.Responses;
using Dominio.Produtos.Servicos.Interfaces;
using NHibernate;

namespace Aplicacao.Produtos.Servicos
{
    public class ProdutosAppServico : IProdutosAppServico
    {
        private readonly IMapper mapper;
        private readonly ISession session;
        private readonly IProdutosServico produtoServico;

        public ProdutosAppServico(IMapper mapper, ISession session, IProdutosServico produtoServico)
        {
            this.mapper = mapper;
            this.session = session;
            this.produtoServico = produtoServico;
        }

        public void Editar(ProdutoInserirRequest produtoRequest, int id)
        {
            var transacao = session.BeginTransaction();
            try
            {
                produtoServico.Atualizar(produtoRequest.Nome, produtoRequest.Valor, id);
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
            var transacao = session.BeginTransaction();
            try
            {
                produtoServico.Excluir(id);
                transacao.Commit();
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
        }

        public ProdutoInserirResponse InserirProduto(ProdutoInserirRequest produtoInserirRequest)
        {
            var transacao = session.BeginTransaction();
            try
            {
                var produto = produtoServico.Instanciar(produtoInserirRequest.Nome, produtoInserirRequest.Valor);
                produtoServico.InserirProduto(produto);
                transacao.Commit();
                return mapper.Map<ProdutoInserirResponse>(produto);
            }
            catch
            {
                transacao.Rollback();
                throw;
            }
        }

        public ProdutoResponse Recuperar(int id)
        {
            var produto = produtoServico.Validar(id);
            return mapper.Map<ProdutoResponse>(produto);
        }
    }
}