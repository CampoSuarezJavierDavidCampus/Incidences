using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingPlaceProfile: Profile{
   public MappingPlaceProfile(){
       CreateMap<PlaceDto,Place>()
           .ReverseMap();
    }
}