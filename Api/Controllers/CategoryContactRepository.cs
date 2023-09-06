using Application.Repositories.Generics;
using Domain.Entities;
using Domain.Interface;
using Persistence;

namespace Application.Repositories;
public class CategoryContactRepository : GenericRepositoryWithIntId<CategoryContact>, ICategoryContactRepository{
    public CategoryContactRepository(ApiContext context) : base(context){}
}
