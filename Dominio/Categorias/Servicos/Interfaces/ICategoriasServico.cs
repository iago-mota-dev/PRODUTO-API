using Dominio.Categorias.Entidades;
using Dominio.Produtos.Entidades;

namespace Dominio.Categorias.Servicos.Interfaces;

public interface ICategoriasServico
{
    Categoria Inserir(string nome, Categoria categoriaPrincipal);
    void Editar(int id, string nome, bool status, Categoria categoriaPrincipal);
    void AdicionarProdutos(Categoria categoria, IList<Produto> produtos);
    void AdicionarSubcategorias(Categoria categoria, IList<Categoria> subcategorias);
    Categoria Validar(int id);
}