using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingIncidenceProfile: Profile{
   public MappingIncidenceProfile(){
       CreateMap<IncidenceDto,Incidence>()
           .ReverseMap();
    }
}