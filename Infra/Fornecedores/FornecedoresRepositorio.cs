using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Fornecedores.Entidades;
using Dominio.Fornecedores.Repositorios;
using Infra.Generico;
using NHibernate;

namespace Infra.Fornecedores
{
    public class FornecedoresRepositorio : GenericoRepositorio<Fornecedor>, IFornecedoresRepositorio
    {
        public FornecedoresRepositorio(ISession session) : base(session)
        {
        }
    }
}