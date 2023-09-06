using Domain.Entities.Generics;

namespace Domain.Entities;

public class Place:BaseEntityWithIntId{

    public string? Name { get; set; }    

    public int? IdAreaFk { get; set; }
    public Area ? Area { get; set; }

    public ICollection<Incidence>? Incidences { get; set; }
}