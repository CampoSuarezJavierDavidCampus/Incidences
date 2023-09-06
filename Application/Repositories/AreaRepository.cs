
using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;

namespace Application.Repositories;
public class AreaRepository : GenericRepositoryWithIntId<Area>, IAreaRepository{
    public AreaRepository(ApiContext context) : base(context){}
}
