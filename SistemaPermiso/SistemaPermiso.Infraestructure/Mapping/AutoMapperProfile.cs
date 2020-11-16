using AutoMapper;
using SistemaPermiso.Core.Dtos;
using SistemaPermiso.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaPermiso.Infraestructure.Mapping
{
    //Implementation Automapper
   public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Permmisions, PermmisionDto>().ReverseMap();
            CreateMap<PermmisionsType, PermmisionTypeDto>().ReverseMap();
            CreateMap<Permmisions, PermmisionsCreateDto>().ReverseMap();
            CreateMap<Permmisions, UpdatePermmisionsDto>().ReverseMap();
            

        }

       

    }
}
