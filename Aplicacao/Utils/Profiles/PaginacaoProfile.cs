using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Utils;

namespace Aplicacao.Utils.Profiles
{
    public class PaginacaoProfile : Profile
    {
        public PaginacaoProfile()
        {
            CreateMap(typeof(Paginacao<>), typeof(Paginacao<>));
        }
    }
}