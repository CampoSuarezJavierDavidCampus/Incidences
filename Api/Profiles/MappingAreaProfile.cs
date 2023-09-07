using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingAreaProfile: Profile{
   public MappingAreaProfile(){
       CreateMap<AreaDto,Area>()
            .ForMember(x => x.IdPk, opt => opt.MapFrom(src => src.Id))

           .ReverseMap();
    }
}