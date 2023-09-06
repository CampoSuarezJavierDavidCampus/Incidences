
using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;


namespace Application.Repositories;
public class PlaceRepository : GenericRepositoryWithIntId<Place>, IPlaceRepository{
    public PlaceRepository(ApiContext context) : base(context){}
}
