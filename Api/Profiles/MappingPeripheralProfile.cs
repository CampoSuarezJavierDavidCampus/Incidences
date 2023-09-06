using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingPeripheralProfile: Profile{
   public MappingPeripheralProfile(){
       CreateMap<PeripheralDto,Peripheral>()
           .ReverseMap();
    }
}