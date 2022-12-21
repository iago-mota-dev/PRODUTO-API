using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Generico.Repositorios;
using Dominio.Produtos.Entidades;
using Dominio.Produtos.Repositorios;
using Infra.Generico;
using NHibernate;

namespace Infra.Produtos
{
    public class ProdutosRepositorio : GenericoRepositorio<Produto>, IProdutosRepositorio
    {
        public ProdutosRepositorio(ISession session) : base(session)
        {
        }
    }
}