using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingLevelIncidenceProfile: Profile{
   public MappingLevelIncidenceProfile(){
       CreateMap<LevelIncidenceDto,LevelIncidence>()
           .ReverseMap();
    }
}