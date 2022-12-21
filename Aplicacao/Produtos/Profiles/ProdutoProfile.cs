using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataTransfer.Produtos.Requests;
using DataTransfer.Produtos.Responses;
using Dominio.Produtos.Entidades;

namespace Aplicacao.Produtos.Profiles
{
    public class ProdutoProfile : Profile
    {
        public ProdutoProfile()
        {
            CreateMap<Produto, ProdutoResponse>();
            CreateMap<Produto, ProdutoInserirResponse>();
            CreateMap<ProdutoInserirRequest, Produto>();
        }
    }
}