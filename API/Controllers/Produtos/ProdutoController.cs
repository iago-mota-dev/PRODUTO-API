using Aplicacao.Produtos.Servicos.Interfaces;
using DataTransfer.Produtos.Requests;
using DataTransfer.Produtos.Responses;
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
        [HttpPost]
        public ActionResult<ProdutoInserirResponse> Inserir([FromBody] ProdutoInserirRequest produtoRequest)
        {
            ProdutoInserirResponse produto = produtosAppServico.InserirProduto(produtoRequest);
            return Ok(produto);
        }

        [HttpGet("{id}")]
        public ActionResult<ProdutoResponse> Recuperar(int id)
        {
            ProdutoResponse response = produtosAppServico.Recuperar(id);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public ActionResult Excluir(int id)
        {
            produtosAppServico.Excluir(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Editar([FromBody] ProdutoInserirRequest produtoRequest, int id)
        {
            produtosAppServico.Editar(produtoRequest, id);
            return Ok();
        }

    }
}