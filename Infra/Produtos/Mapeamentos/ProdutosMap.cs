using Dominio.Produtos.Entidades;
using FluentNHibernate.Mapping;

namespace Infra.Produtos.Mapeamentos
{
    public class ProdutosMap : ClassMap<Produto>
    {
        public ProdutosMap()
        {
            Schema("BIBLIOTECA");
            Table("PRODUTO");
            Id(x => x.Id).Column("ID");
            Map(x => x.Nome).Column("NOME");
            Map(x => x.Valor).Column("VALOR");
            Map(x => x.Validade).Column("VALIDADE");
        }
    }
}