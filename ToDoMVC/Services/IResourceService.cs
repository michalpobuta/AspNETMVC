using ToDoMVC.Models;
using Task = System.Threading.Tasks.Task;

namespace ToDoMVC.Services;

public interface IResourceService<T> where T : ModelBase
{
    public Task<T> Create(T resource);
    public Task<T> GetResourceById(int id);
    public Task<IList<T>> GetResources();
    public Task Update(T resource);
    public Task Delete(T resource);
}