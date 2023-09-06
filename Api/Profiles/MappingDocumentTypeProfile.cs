using Api.Dtos;
using AutoMapper;
using Domain.Entities;
namespace Api.Profiles;
public class MappingDocumentTypeProfile: Profile{
   public MappingDocumentTypeProfile(){
       CreateMap<DocumentTypeDto,DocumentType>()
           .ReverseMap();
    }
}