using Dominio.Categorias.Entidades;
using Dominio.Categorias.Repositorios;
using Dominio.Categorias.Servicos.Interfaces;
using Dominio.Generico.Excecoes;
using Dominio.Produtos.Entidades;

namespace Dominio.Categorias.Servicos;

public class CategoriasServico : ICategoriasServico // DIFICIL
{
    private readonly ICategoriasRepositorio categoriasRepositorio;

    // Finalizar serviço
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
        //FINALIZAR REGRA DE PRODUTO DEFINIDA NA INTERFACE
        foreach (Produto produto in produtos)
        {
            categoria.Produtos.Add(produto);
        }
        
        categoriasRepositorio.Atualizar(categoria); //CASCADE
    }

    public void AdicionarSubcategorias(Categoria categoria, IList<Categoria> subcategorias)
    {
        if (VerificarCategoriaPrincipalEmSubcategorias(categoria, subcategorias))
        {
            throw new RegraInvalidaExcecao();
        }

        if (VerificaSubcategoriaJaExistente(categoria, subcategorias))
        {
            throw new RegraInvalidaExcecao();
        }

        foreach (var subcategoria in subcategorias)
        {
            categoria.Subcategorias.Add(categoria);
        }

        categoriasRepositorio.Atualizar(categoria); //CASCADE
    }

    private bool VerificaSubcategoriaJaExistente(Categoria categoria, IList<Categoria> subcategorias)
    {
        /*foreach (var subcategoria in subcategorias) REVISAR LÓGICA
        {
            if (categoria.Subcategorias.Any(x => x.Id == subcategoria.Id) || VerificaSubcategoriaJaExistente(subcategoria, subcategoria.Subcategorias))
            {
                return true;
            }
        }
        return false;
        */
        return true;
    }

    private bool VerificarCategoriaPrincipalEmSubcategorias(Categoria categoriaPrincipal,
        IList<Categoria> subcategorias)
    {
        foreach (Categoria subcategoria in subcategorias)
        {
            if (subcategoria.Id == categoriaPrincipal.Id ||
                VerificarCategoriaPrincipalEmSubcategorias(categoriaPrincipal, subcategoria.Subcategorias))
            {
                return true;
            }
        }

        return false;
    }

    public Categoria Validar(int id)
    {
        Categoria categoria = categoriasRepositorio.Recuperar(id);

        if (categoria is null)
            throw new RegistroNaoEncontradoExcecao();

        return categoria;
    }
}