namespace Dominio.Generico.Excecoes;

public class RegistroNaoEncontradoExcecao : Exception
{
    public RegistroNaoEncontradoExcecao(string mensagem = "") : base(mensagem)
    {
        
    }
}