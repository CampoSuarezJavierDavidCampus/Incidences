using System.ComponentModel.DataAnnotations;
using Domain.Entities.Generics;

namespace Domain.Entities;
public class Person: BaseEntityWithStrinId{
    public string? Name { get; set; }
    public string? Lastname { get; set; }
    public string? Address { get; set; }

    public int IdDocumentTypeFk { get; set; }
    public DocumentType? DocumentType { get; set; }

    public int IdRolFk { get; set; }
    public Rol? Rol { get; set; }

    public int IdUserFk { get; set; }
    public User? User { get; set; }

    public ICollection<Contact>? Contacts { get; set; }
    public ICollection<AreaPerson>? AreaPerson { get; set; }
    public ICollection<Incidence>? Incidences { get; set; }
}