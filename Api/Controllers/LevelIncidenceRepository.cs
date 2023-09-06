using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;


namespace Application.Repositories;
public class LevelIncidenceRepository : GenericRepositoryWithIntId<LevelIncidence>, ILevelIncidenceRepository{
    public LevelIncidenceRepository(ApiContext context) : base(context){}
}
