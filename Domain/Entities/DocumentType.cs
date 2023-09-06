using Domain.Entities.Generics;

namespace Domain.Entities;

public class DocumentType:BaseEntityWithIntId{
    public string? Name { get; set; }
    public string? Abbreviation { get; set; }    

    public ICollection<Person>? Person{ get; set; }
}