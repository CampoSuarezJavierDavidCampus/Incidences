
using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;


namespace Application.Repositories;
public class PersonRepository : GenericRepositoryWithStringId<Person>, IPersonRepository{
    public PersonRepository(ApiContext context) : base(context){}
}
