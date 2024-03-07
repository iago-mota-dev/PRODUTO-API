using Dominio.Categorias.Entidades;
using Dominio.Produtos.Entidades;

namespace Dominio.Categorias.Servicos.Interfaces;

public interface ICategoriasServico
{
    // INSERIR
    Categoria Inserir(string nome, Categoria categoriaPrincipal);
    // EDITAR
    void Editar(int id, string nome, bool status, Categoria categoriaPrincipal);
    // ADICIONAR PRODUTOS, UM PRODUTO SÓ PODE ESTAR EM ATÉ 3 CATEGORIAS, MAS UMA DEVE SER A CATEGORIA PRINCIPAL
    void AdicionarProdutos(Categoria categoria, IList<Produto> produtos);
    // ADICIONAR SUBCATEGORIAS, NÃO DEVE SER POSSÍVEL REFERENCIA PROPRIA
    void AdicionarSubcategorias(Categoria categoria, IList<Categoria> subcategorias);
    // VALIDAR
    Categoria Validar(int id);
}