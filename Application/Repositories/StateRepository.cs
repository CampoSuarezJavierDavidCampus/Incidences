
using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;


namespace Application.Repositories;
public class StateRepository : GenericRepositoryWithIntId<State>, IStateRepository{
    public StateRepository(ApiContext context) : base(context){}
}
