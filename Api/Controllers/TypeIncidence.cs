using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;

namespace Application.Repositories;
public class TypeIncidenceRepository : GenericRepositoryWithIntId<Incidence>, ITypeIncidenceRepository{
    public TypeIncidenceRepository(ApiContext context) : base(context){}
}
