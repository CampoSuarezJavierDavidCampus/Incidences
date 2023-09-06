using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;

namespace Application.Repositories;
public class DetailIncidenceRepository : GenericRepositoryWithIntId<DetailIncidence>, IDetailIncidenceRepository{
    public DetailIncidenceRepository(ApiContext context) : base(context){}
}
