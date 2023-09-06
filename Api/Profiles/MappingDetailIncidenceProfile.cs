using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingDetailIncidenceProfile: Profile{
   public MappingDetailIncidenceProfile(){
       CreateMap<DetailIncidenceDto,DetailIncidence>()
           .ReverseMap();
    }
}