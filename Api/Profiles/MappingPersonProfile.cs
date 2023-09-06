using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingPersonProfile: Profile{
   public MappingPersonProfile(){
       CreateMap<PersonDto,Person>()
           .ReverseMap();
    }
}