using Dominio.Marcas.Enumeradores;
using Dominio.Produtos.Entidades;

namespace Dominio.Marcas.Entidades;

public class Marca
{
    public virtual int Id { get; protected set; }
    public virtual string Descricao { get; protected set; }
    public virtual IList<Produto> Produtos { get; protected set; } = new List<Produto>();
    public virtual bool Status { get; protected set; }
    public virtual ReputacaoEnum Reputacao { get; protected set; }

    protected Marca()
    {
    }

    public Marca(string descricao, bool status, ReputacaoEnum reputacaoEnum)
    {
        SetDescricao(descricao);
        SetStatus(status);
        SetReputacao(reputacaoEnum);
    }

    public virtual void SetDescricao(string descricao)
    {
        if (String.IsNullOrWhiteSpace(descricao))
        {
            throw new Exception("Descrição é obrigatória");
        }
        Descricao = descricao;
    }

    public virtual void SetStatus(bool status)
    {
        Status = status;
    }
    public virtual void SetReputacao(ReputacaoEnum reputacao)
    {
        Reputacao = reputacao;
    }
}