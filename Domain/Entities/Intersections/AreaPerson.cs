using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;
public class AreaPerson{
    public int IdAreaPk { get; set; }
    public Area? Area { get; set; }
    
    public int IdPersonPk { get; set; }
    public Person? Person { get; set; }
}