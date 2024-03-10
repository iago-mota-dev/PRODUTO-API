using Dominio.Marcas.Entidades;
using Dominio.Marcas.Enumeradores;
using Dominio.Produtos.Entidades;

namespace Dominio.Marcas.Servicos.Interfaces;

public interface IMarcasServico
{
    Marca Validar(int id);
    void Editar(int id, ReputacaoEnum reputacao, string descricao, bool status);
    Marca Inserir(ReputacaoEnum reputacao, string descricao, bool status);
    void AdicionarProdutos(Marca marca, IList<Produto> produtos);
    void RemoverProdutos(Marca marca, IList<Produto> produtos);
}