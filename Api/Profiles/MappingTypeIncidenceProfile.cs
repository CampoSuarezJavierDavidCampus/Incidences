using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingTypeIncidenceProfile: Profile{
   public MappingTypeIncidenceProfile(){
       CreateMap<TypeIncidenceDto,TypeIncidence>()
           .ReverseMap();
    }
}