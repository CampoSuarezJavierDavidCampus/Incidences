using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingContactTypeProfile: Profile{
   public MappingContactTypeProfile(){
       CreateMap<ContactTypeDto,ContactType>()
           .ReverseMap();
    }
}