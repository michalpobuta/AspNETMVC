using ToDoMVC.Utils;

namespace ToDoMVC.Models;

public class TaskModel : ModelBase
{
    public string? Title { get; set; }
    public State State { get; set; }
    public CategoryModel? Category { get; set; }
    public string? Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}

