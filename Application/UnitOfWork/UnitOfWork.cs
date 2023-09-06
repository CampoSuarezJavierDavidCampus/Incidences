using Application.Repositories;
using Domain.Interface;
using Persistence;

namespace Application.UnitOfWork;
public class UnitOfWork : IUnitOfWork,IDisposable{
    private readonly ApiContext _Context;
    private  IUserRepository? _User;
    private  IRolRepository? _Rol;
    private  IAreaRepository? _Area;
    private  ICategoryContactRepository? _CategoryContact;
    private  IContactTypeRepository? _ContactType;
    private  IDetailIncidenceRepository? _DetailIncidence;
    private  IDocumentTypeRepository? _DocumentType;
    private  IIncidenceRepository? _Incidence;
    private  ILevelIncidenceRepository? _LevelIncidence;
    private  IPeripheralRepository? _Peripheral;
    private  IPersonRepository? _Person;
    private  IPlaceRepository? _Place;
    private  IStateRepository? _State;
    private  ITypeIncidenceRepository? _TypeIncidence;


    public UnitOfWork(ApiContext Context) => _Context = Context;

    public IAreaRepository Areas => _Area ??= new AreaRepository(_Context);
    public ICategoryContactRepository CategoryContacts => _CategoryContact ??= new CategoryContactRepository(_Context);
    public IContactTypeRepository ContactTypes => _ContactType ??= new ContactTypeRepository(_Context);
    public IDetailIncidenceRepository DetailIncidences => _DetailIncidence ??= new DetailIncidenceRepository(_Context);
    public IDocumentTypeRepository DocumentTypes => _DocumentType ??= new DocumentTypeRepository(_Context);
    public IIncidenceRepository Incidences => _Incidence ??= new IncidenceRepository(_Context);
    public ILevelIncidenceRepository LevelIncidences => _LevelIncidence ??= new LevelIncidenceRepository(_Context);
    public IPeripheralRepository Peripherals => _Peripheral ??= new PeripheralRepository(_Context);
    public IPersonRepository Persons => _Person ??= new PersonRepository(_Context);
    public IPlaceRepository Places => _Place ??= new PlaceRepository(_Context);
    public IRolRepository Rols =>  _Rol ??= new RolRepository(_Context);
    public IStateRepository States => _State ??= new StateRepository(_Context);
    public ITypeIncidenceRepository TypeIncidences => _TypeIncidence ??= new TypeIncidenceRepository(_Context);
    public IUserRepository Users => _User ??= new UserRepository(_Context);
    public virtual async Task<int> SaveChanges()=>await _Context.SaveChangesAsync();    

    public virtual void Dispose(){
        _Context.Dispose();
        GC.SuppressFinalize(this); 
    }
}
