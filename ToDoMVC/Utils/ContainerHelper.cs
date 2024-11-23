using ToDoMVC.Services;
using ToDoMVC.Models;

namespace ToDoMVC.Utils;

public static class ContainerHelper
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddSingleton<IResourceService<CategoryModel>, CategoryService>();
        services.AddSingleton<IResourceService<TaskModel>, TaskService>();

        return services;
    }
}
