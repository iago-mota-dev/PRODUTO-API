using Aplicacao.Produtos.Servicos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Produtos
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutosAppServico produtosAppServico;
        public ProdutoController(IProdutosAppServico produtosAppServico)
        {
            this.produtosAppServico = produtosAppServico;
        }

        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        {
            produtosAppServico.Excluir(id);
            return Ok();
        }
    }
}