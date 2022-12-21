using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Generico.Repositorios;
using NHibernate;

namespace Infra.Generico
{
    public class GenericoRepositorio<T> : IGenericoRepositorio<T>
    {
         protected readonly ISession session;

        public GenericoRepositorio(ISession session)
        {
            this.session = session;
        }

        public T Atualizar(T entidade)
        {
            session.Update(entidade);
            return entidade;
        }

        public void Excluir(T entidade)
        {
            session.Delete(entidade);
        }

        public T Inserir(T entidade)
        {
            session.Save(entidade);
            return entidade;
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

        public T Recuperar(int id)
        {
            return session.Get<T>(id);
        }
    }
}