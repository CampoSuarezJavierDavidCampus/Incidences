using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class AreaPerson{
    public int IdAreaPk { get; set; }
    public Area? Area { get; set; }
    
    public string IdPersonPk { get; set; } = null!;
    public Person? Person { get; set; }
}