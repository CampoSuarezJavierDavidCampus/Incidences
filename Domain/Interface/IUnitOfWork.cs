namespace Domain.Interface;
public interface IUnitOfWork{
    IAreaRepository Areas { get; }
    ICategoryContactRepository CategoryContacts { get; }
    IContactTypeRepository ContactTypes { get; }
    IDetailIncidenceRepository DetailIncidences { get; }
    IDocumentTypeRepository DocumentTypes { get; }
    IIncidenceRepository Incidences { get; }
    ILevelIncidenceRepository LevelIncidences { get; }
    IPeripheralRepository Peripherals { get; }
    IPersonRepository Persons { get; }
    IPlaceRepository Places { get; }
    IRolRepository Rols { get; }
    IStateRepository States { get; }
    ITypeIncidenceRepository TypeIncidences { get; }
    IUserRepository Users { get; }

    Task<int> SaveChanges();

    void Dispose();
}
