using ARQUICAPAS.Application.Dtos.Encargado.Request;
using ARQUICAPAS.Application.Dtos.Encargado.Response;
using ARQUICAPAS.Domain.Entities;
using ARQUICAPAS.Infrastructure.Commons.Bases.Response;
using ARQUICAPAS.Utilities.Static;
using AutoMapper;

namespace ARQUICAPA.Application.Mappers
{
    public class EncargadoMappingProfile : Profile
    {
        public EncargadoMappingProfile()
        {
            CreateMap<Encargado, EncargadoResponseDto>()
                .ForMember(x => x.EncargadoId, x => x.MapFrom(y => y.Id))
                .ForMember(x => x.StateEncargado, x => x.MapFrom(y => y.State.Equals((int)StateTypes.Active) ? "Activo" : "Inactivo")).ReverseMap();

            CreateMap<BaseEntityResponse<Encargado>, BaseEntityResponse<EncargadoResponseDto>>()
                .ReverseMap();

            CreateMap<EncargadoRequestDto, Encargado>();

            CreateMap<Encargado, EncargadoSelectResponseDto>()
                 .ForMember(x => x.EncargadoId, x => x.MapFrom(y => y.Id))
                .ReverseMap();
        }
    }
}
