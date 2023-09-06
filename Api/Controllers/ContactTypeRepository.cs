using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;

namespace Application.Repositories;
public class ContactTypeRepository : GenericRepositoryWithIntId<ContactType>, IContactTypeRepository{
    public ContactTypeRepository(ApiContext context) : base(context){}
}
