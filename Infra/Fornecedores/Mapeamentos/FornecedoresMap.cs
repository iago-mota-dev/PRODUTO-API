using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Fornecedores.Entidades;
using FluentNHibernate.Mapping;
using NHibernate.Type;

namespace Infra.Fornecedores.Mapeamentos
{
    public class FornecedoresMap : ClassMap<Fornecedor>
    { 
        public FornecedoresMap()
        {
            Schema("productApi");
            Table("supplier");
            Id(x => x.Id).Column("id");
            Map(x => x.Nome).Column("supplierName");
            Map(x => x.Status).Column("status").CustomType<BooleanType>();
            Map(x => x.ValidadeContratual).Column("contractTime");
            HasManyToMany(x => x.Produtos).Table("productsupplier").Inverse().Cascade.All();
        }
    }
}