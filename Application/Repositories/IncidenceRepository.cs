using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;

namespace Application.Repositories;
public class IncidenceRepository : GenericRepositoryWithIntId<Incidence>, IIncidenceRepository{
    public IncidenceRepository(ApiContext context) : base(context){}
}