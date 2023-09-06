using Domain.Entities.Generics;
namespace Domain.Entities;

public class Incidence:BaseEntityWithIntId{    
    public string? Description { get; set; }
    public string? Detail { get; set; }
    public DateTime Date { get; set; }


    public string IdPersonFk { get; set; } = null!;
    public Person? Person { get; set; }

    public int IdStateFk { get; set; }
    public State? States { get; set; }

    public int IdAreaFk { get; set; }
    public Area? Areas { get; set; }

    public int IdPlaceFk { get; set; }
    public Place? Place { get; set; }


    public ICollection<DetailIncidence>? DetailIncidences  { get; set; }

}