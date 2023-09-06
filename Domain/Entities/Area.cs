using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;

namespace Domain.Entities;

public class Area:BaseEntityWithIntId{    
    public string? Name { get; set; }    

    public ICollection<Place>? Places { get; set; }
    public ICollection<Incidence>? Incidences { get; set; }
    public ICollection<AreaPerson>? AreaPerson { get; set; }
}