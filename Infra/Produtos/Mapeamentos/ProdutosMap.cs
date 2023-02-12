using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Produtos.Entidades;
using FluentNHibernate.Mapping;

namespace Infra.Produtos.Mapeamentos
{
    public class ProdutosMap : ClassMap<Produto>
    {
        public ProdutosMap()
        {
            Schema("productApi");
            Table("product");
            Id(x => x.Id).Column("id");
            Map(x => x.Nome).Column("productName");
            Map(x => x.Valor).Column("price");
            Map(x => x.Validade).Column("expiry");
            HasManyToMany(x => x.Fornecedores).Table("productsupplier").Inverse().Cascade.All();
        }
    }
}