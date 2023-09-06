namespace Domain.Entities;

public class Contact{
    public string? Description { get; set; }

    public string IdPersonPk { get; set; } = null!;
    public Person? Person { get; set; }

    public int IdTypeContactPk { get; set; }
    public ContactType? TypeOfContact { get; set; }

    public int IdCategoryContactPk { get; set; }
    public CategoryContact? CategoryContact { get; set; }

}