namespace ToDoMVC.Models;

public abstract class ModelBase
{
    private static int _id = 0;

    protected ModelBase()
    {
        Id = _id++;
    }
    
    public int Id { get; init; }
}