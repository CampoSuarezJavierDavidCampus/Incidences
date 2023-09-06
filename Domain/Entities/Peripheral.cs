using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;

namespace Domain.Entities;
public class Peripheral:BaseEntityWithIntId
{
    public string? Name { get; set; }

    public int IdDetailIncidenceFk { get; set; }
    public DetailIncidence ? DetailIncidence { get; set; }
}