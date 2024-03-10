using Dominio.Produtos.Entidades;

namespace Dominio.Categorias.Entidades;

public class Categoria
{
    public virtual int Id { get; protected set; }
    public virtual string Nome { get; protected set; }
    public virtual bool Status { get; protected set; }
    public virtual IList<Produto> Produtos { get; protected set; } = new List<Produto>();
    public virtual Categoria CategoriaPrincipal { get; protected set; }
    public virtual IList<Categoria> Subcategorias { get; protected set; } = new List<Categoria>();

    protected Categoria()
    {
    }

    public Categoria(string nome, bool status, Categoria categoriaPrincipal)
    {
        SetNome(nome);
        SetStatus(status);
        SetCategoriaPrincipal(categoriaPrincipal);
    }

    public virtual void SetCategoriaPrincipal(Categoria categoriaPrincipal)
    {
        CategoriaPrincipal = categoriaPrincipal;
    }

    public virtual void SetStatus(bool status)
    {
        Status = status;
    }

    public virtual void SetNome(string nome)
    {
        if (String.IsNullOrWhiteSpace(nome))
        {
            throw new Exception("Nome é obrigatório");
        }

        Nome = nome;
    }
}