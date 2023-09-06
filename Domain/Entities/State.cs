using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;

namespace Domain.Entities;

public class State:BaseEntityWithIntId{
    public string? Description { get; set; }    

    public ICollection<Incidence>? Incidences { get; set; }
    public ICollection<DetailIncidence>? DetailIncidences { get; set; }
}