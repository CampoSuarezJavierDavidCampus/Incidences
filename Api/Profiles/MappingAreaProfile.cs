using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingAreaProfile: Profile{
   public MappingAreaProfile(){
       CreateMap<AreaDto,Area>()
           .ReverseMap();
    }
}