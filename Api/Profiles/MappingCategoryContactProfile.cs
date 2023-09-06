using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingCategoryContactProfile: Profile{
   public MappingCategoryContactProfile(){
       CreateMap<CategoryContactDto,CategoryContact>()
           .ReverseMap();
    }
}