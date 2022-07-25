using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = P.DAL.DO.Objects;

namespace P.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<data.CalculoMateri, Models.CalculoMateri>().ReverseMap();
            CreateMap<data.Canton, Models.Canton>().ReverseMap();
            CreateMap<data.Cliente, Models.Cliente>().ReverseMap();
            CreateMap<data.ListCal, Models.ListCal>().ReverseMap();
            CreateMap<data.Materiales, Models.Materiales>().ReverseMap();
            CreateMap<data.MediPared, Models.MediPared>().ReverseMap();
            CreateMap<data.MediParedes, Models.MediParedes>().ReverseMap();
            CreateMap<data.Persona, Models.Persona>().ReverseMap();
            CreateMap<data.Provincia, Models.Provincia>().ReverseMap();

        }
    }
}
