using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingStateProfile: Profile{
   public MappingStateProfile(){
       CreateMap<StateDto,State>()
           .ReverseMap();
    }
}