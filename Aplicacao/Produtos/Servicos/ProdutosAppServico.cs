using Aplicacao.Produtos.Servicos.Interfaces;
using Dominio.Produtos.Servicos.Interfaces;
using NHibernate;

namespace Aplicacao.Produtos.Servicos
{
    public class ProdutosAppServico : IProdutosAppServico
    {
        private readonly ISession session;
        private readonly IProdutosServico produtoServico;

        public ProdutosAppServico(ISession session, IProdutosServico produtoServico)
        {
            this.session = session;
            this.produtoServico = produtoServico;
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
    }
}