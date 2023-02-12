using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aplicacao.Fornecedores.Servicos.Interfaces;
using DataTransfer.Fornecedores.Requests;
using DataTransfer.Fornecedores.Responses;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Fornecedores
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedorController : ControllerBase
    {
        private readonly IFornecedoresAppServico fornecedoresAppServico;
        public FornecedorController(IFornecedoresAppServico fornecedoresAppServico)
        {
            this.fornecedoresAppServico = fornecedoresAppServico;
        }
        [HttpPost]
        public ActionResult Inserir([FromBody] FornecedorRequest request)
        {
            fornecedoresAppServico.Inserir(request);
            return Ok();
        }

        [HttpPut]
        public ActionResult Editar([FromBody] FornecedorRequest request, int id)
        {
            fornecedoresAppServico.Atualizar(request, id);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<FornecedorResponse> Recuperar(int id)
        {
            var fornecedor = fornecedoresAppServico.Recuperar(id);
            return Ok(fornecedor);
        }
        [HttpDelete("{id}")]
        public ActionResult<FornecedorResponse> Excluir(int id)
        {
            fornecedoresAppServico.Excluir(id);
            return Ok();
        }

    }
}
