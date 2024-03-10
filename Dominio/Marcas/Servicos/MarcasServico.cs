using Dominio.Generico.Excecoes;
using Dominio.Marcas.Entidades;
using Dominio.Marcas.Enumeradores;
using Dominio.Marcas.Repositorios;
using Dominio.Marcas.Servicos.Interfaces;
using Dominio.Produtos.Entidades;

namespace Dominio.Marcas.Servicos;

public class MarcasServico : IMarcasServico
{
    private readonly IMarcasRepositorio marcasRepositorio;

    public MarcasServico(IMarcasRepositorio marcasRepositorio)
    {
        this.marcasRepositorio = marcasRepositorio;
    }

    public Marca Validar(int id)
    {
        Marca marca = marcasRepositorio.Recuperar(id);
        if (marca is null)
        {
            throw new RegistroNaoEncontradoExcecao("Marca não econtrada");
        }

        return marca;
    }

    public void Editar(int id, ReputacaoEnum reputacao, string descricao, bool status)
    {
        Marca marca = Validar(id);

        marca.SetReputacao(reputacao);
        marca.SetDescricao(descricao);
        marca.SetStatus(status);

        marcasRepositorio.Atualizar(marca);
    }

    public Marca Inserir(ReputacaoEnum reputacao, string descricao, bool status)
    {
        Marca marca = new(descricao, status, reputacao);

        marcasRepositorio.Inserir(marca);

        return marca;
    }

    public void AdicionarProdutos(Marca marca, IList<Produto> produtos)
    {
        foreach (var produto in produtos)
        {
            ValidarProdutoExistente(marca, produto);

            marca.Produtos.Add(produto);
        }

        marcasRepositorio.Atualizar(marca);
    }

    private static void ValidarProdutoExistente(Marca marca, Produto produto)
    {
        bool existeProduto = marca.Produtos.Any(x => x.Id == produto.Id);

        if (existeProduto)
        {
            throw new RegraInvalidaExcecao("Esse produto já está associado a essa marca");
        }
    }

    public void RemoverProdutos(Marca marca, IList<Produto> produtos)
    {
        foreach (var produto in produtos)
        {
            bool existeProdutoParaRemover = marca.Produtos.Any(x => x.Id == produto.Id);

            if (existeProdutoParaRemover)
            {
                marca.Produtos.Remove(produto);
            }
        }
    }
}