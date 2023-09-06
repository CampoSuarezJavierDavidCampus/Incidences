using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;


namespace Application.Repositories;
public class PeripheralRepository : GenericRepositoryWithIntId<Peripheral>, IPeripheralRepository{
    public PeripheralRepository(ApiContext context) : base(context){}
}
