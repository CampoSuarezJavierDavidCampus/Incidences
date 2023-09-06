using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;

namespace Application.Repositories;
public class DocumentTypeRepository : GenericRepositoryWithIntId<DocumentType>, IDocumentTypeRepository{
    public DocumentTypeRepository(ApiContext context) : base(context){}
}
