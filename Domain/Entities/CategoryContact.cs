using Domain.Entities.Generics;

namespace Domain.Entities;
public class CategoryContact:BaseEntityWithIntId{
    public string? Name { get; set; }

    public ICollection<Contact>? Contacts { get; set; }
}