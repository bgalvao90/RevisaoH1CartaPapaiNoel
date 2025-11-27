using AutoMapper;
using Revisao.Api.DTO;
using Revisao.Domain.Entities;

namespace Revisao.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        { 
            CreateMap<CriancaRequestDto, Crianca>().ReverseMap();
        }
    }
}
