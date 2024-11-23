using ToDoMVC.Models;

namespace ToDoMVC.Services;

public class TaskService : IResourceService<TaskModel>
{
    private readonly SortedDictionary<int, TaskModel> _tasks = new();

    public Task<TaskModel> Create(TaskModel resource)
    {
        if (_tasks.TryAdd(resource.Id, resource))
            return Task.FromResult(resource);
        throw new Exception("Resource already exist") ;
    }

    public Task<TaskModel> GetResourceById(int id)
    {
        if (_tasks.TryGetValue(id, out var task))
            return Task.FromResult(task);
        throw new KeyNotFoundException();
    }

    public Task<IList<TaskModel>> GetResources()
    {
        return Task.FromResult<IList<TaskModel>>(_tasks.Values.ToList());
    }

    public Task Update(TaskModel resource)
    {
        if (!_tasks.ContainsKey(resource.Id))
            throw new KeyNotFoundException();

        _tasks[resource.Id] = resource;
        return Task.CompletedTask;
    }

    public Task Delete(TaskModel resource)
    {
        if (!_tasks.ContainsKey(resource.Id))
            throw new KeyNotFoundException();

        _tasks.Remove(resource.Id);
        
        return Task.CompletedTask;
    }
}