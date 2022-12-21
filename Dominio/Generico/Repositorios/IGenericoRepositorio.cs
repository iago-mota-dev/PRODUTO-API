namespace Dominio.Generico.Repositorios
{
     public interface IGenericoRepositorio<T>
    {
        T Recuperar(int id);

        T Inserir(T entidade);

        T Atualizar(T entidade);

        void Excluir(T entidade);

        IQueryable<T> Query();
    }
}