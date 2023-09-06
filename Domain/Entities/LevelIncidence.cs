using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;

namespace Domain.Entities;
public class LevelIncidence:BaseEntityWithIntId
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    
    public ICollection<DetailIncidence>? DetailIncidences { get; set; }
}