using Dominio.Categorias.Entidades;
using Dominio.Categorias.Repositorios;
using Dominio.Categorias.Servicos.Interfaces;
using Dominio.Generico.Excecoes;
using Dominio.Produtos.Entidades;

namespace Dominio.Categorias.Servicos;

public class CategoriasServico : ICategoriasServico
{
    private readonly ICategoriasRepositorio categoriasRepositorio;
    
    public CategoriasServico(ICategoriasRepositorio categoriasRepositorio)
    {
        this.categoriasRepositorio = categoriasRepositorio;
    }

    public Categoria Inserir(string nome, Categoria categoriaPrincipal)
    {
        Categoria categoria = new(nome, true, categoriaPrincipal);

        categoriasRepositorio.Inserir(categoria);

        return categoria;
    }

    public void Editar(int id, string nome, bool status, Categoria categoriaPrincipal)
    {
        Categoria categoria = Validar(id);

        categoria.SetNome(nome);
        categoria.SetStatus(status);
        categoria.SetCategoriaPrincipal(categoriaPrincipal);

        categoriasRepositorio.Atualizar(categoria);
    }

    public void AdicionarProdutos(Categoria categoria, IList<Produto> produtos)
    {
        IQueryable<Categoria> query = categoriasRepositorio.Query();

        foreach (Produto produto in produtos)
        {
            ValidarProduto(query, categoria, produto);
            categoria.Produtos.Add(produto);
        }

        categoriasRepositorio.Atualizar(categoria); //CASCADE
    }

    private void ValidarProduto(IQueryable<Categoria> query, Categoria categoria, Produto produto)
    {
        ValidarProdutoEm3Categorias(query, produto);
        ValidarProdutoExistente(categoria, produto);
        ValidarProdutoEmSubcategoria(categoria, produto);
    }

    private static void ValidarProdutoEmSubcategoria(Categoria categoria, Produto produto)
    {
        bool existeProdutoEmAlgumaSubcategoria = categoria.Subcategorias
            .SelectMany(x => x.Produtos)
            .Any(x => x.Id == produto.Id);

        if (existeProdutoEmAlgumaSubcategoria)
        {
            throw new RegraInvalidaExcecao("O produto já existe em uma subcategoria");
        }
    }

    private static void ValidarProdutoExistente(Categoria categoria, Produto produto)
    {
        bool jaExisteProdutoNaCategoria = categoria.Produtos.Any(x => x.Id == produto.Id);

        if (jaExisteProdutoNaCategoria)
        {
            throw new RegraInvalidaExcecao("O produto já existe na categoria");
        }
    }

    private static void ValidarProdutoEm3Categorias(IQueryable<Categoria> query, Produto produto)
    {
        bool produtoJaExisteEm3Categorias = query.Count(x => x.Produtos.Any(y => y.Id == produto.Id)) == 3;
        if (produtoJaExisteEm3Categorias)
        {
            throw new RegraInvalidaExcecao("Não é permitido adicionar um produto em mais de 3 categorias");
        }
    }

    public void AdicionarSubcategorias(Categoria categoria, IList<Categoria> subcategorias)
    {
        ValidarRestricaoDeSubcategoria(categoria);
        
        foreach (var subcategoria in subcategorias)
        {
            ValidarRegrasParaAdicionarSubcategoria(categoria, subcategoria);

            categoria.Subcategorias.Add(categoria);
        }

        categoriasRepositorio.Atualizar(categoria); //CASCADE
    }

    private static void ValidarRegrasParaAdicionarSubcategoria(Categoria categoria, Categoria subcategoria)
    {
        ValidarSubcategoriaJaExistente(categoria, subcategoria);
        ValidarAutoReferencia(categoria, subcategoria);
    }

    private static void ValidarRestricaoDeSubcategoria(Categoria categoria)
    {
        bool existeCategoriaPrincipal = categoria.CategoriaPrincipal is not null;
        if (existeCategoriaPrincipal)
        {
            throw new RegraInvalidaExcecao("Uma subcategoria não pode ter subcategorias");
        }
    }

    private static void ValidarAutoReferencia(Categoria categoria, Categoria subcategoria)
    {
        bool existeReferenciaPropria = subcategoria.Id == categoria.Id;
        if (existeReferenciaPropria)
        {
            throw new RegraInvalidaExcecao("Não é permitido referência própria de categoria");
        }
    }

    private static void ValidarSubcategoriaJaExistente(Categoria categoria, Categoria subcategoria)
    {
        bool jaExisteSubcategoriaVinculada = categoria.Subcategorias.Any(x => x.Id == subcategoria.Id);
        if (jaExisteSubcategoriaVinculada)
        {
            throw new RegraInvalidaExcecao("Subcategoria já vinculada");
        }
    }

    public Categoria Validar(int id)
    {
        Categoria categoria = categoriasRepositorio.Recuperar(id);

        if (categoria is null)
            throw new RegistroNaoEncontradoExcecao();

        return categoria;
    }
}