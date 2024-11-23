namespace ToDoMVC.Models;

public class CategoryModel : ModelBase
{
    public string? Name { get; set; }

    public override string ToString()
    {
        return Name ?? "";
    }
}
