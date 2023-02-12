using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DataTransfer.Fornecedores.Responses;
using Dominio.Fornecedores.Entidades;

namespace Aplicacao.Fornecedores.Profiles
{
    public class FornecedorProfile : Profile
    {
        public FornecedorProfile()
        {
            CreateMap<Fornecedor, FornecedorResponse>();
        }
    }
}