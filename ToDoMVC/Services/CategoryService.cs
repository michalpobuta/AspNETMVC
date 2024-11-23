using ToDoMVC.Models;
using ToDoMVC.Services;
using Task = System.Threading.Tasks.Task;

namespace ToDoMVC.Services;

public class CategoryService : IResourceService<CategoryModel>
{
    private readonly SortedDictionary<int, CategoryModel> _categories = new();

    public Task<CategoryModel> Create(CategoryModel resource)
    {
        if (_categories.TryAdd(resource.Id, resource))
            return Task.FromResult(resource);


        throw new Exception("Resource already exist") ;
    }

    public Task<CategoryModel> GetResourceById(int id)
    {
        if (_categories.TryGetValue(id, out var category))
            return Task.FromResult(category);
        throw new KeyNotFoundException();
    }

    public Task<IList<CategoryModel>> GetResources()
    {
        return Task.FromResult<IList<CategoryModel>>(_categories.Values.ToList());
    }

    public Task Update(CategoryModel resource)
    {
        if (!_categories.ContainsKey(resource.Id))
            throw new KeyNotFoundException();

        _categories[resource.Id] = resource;
        
        return Task.CompletedTask;
    }

    public Task Delete(CategoryModel resource)
    {
        if (!_categories.ContainsKey(resource.Id))
            throw new KeyNotFoundException();

        _categories.Remove(resource.Id);
        
        return Task.CompletedTask;
    }
}