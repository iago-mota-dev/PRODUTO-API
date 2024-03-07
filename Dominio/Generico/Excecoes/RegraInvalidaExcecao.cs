namespace Dominio.Generico.Excecoes;

public class RegraInvalidaExcecao : Exception
{
    public RegraInvalidaExcecao(string mensagem = "") : base(mensagem){}
}