using Microsoft.AspNetCore.Mvc;
using ToDoMVC.Models;
using ToDoMVC.Services;


public class TaskController : Controller
{
    private readonly IResourceService<TaskModel> _taskService;
    private readonly IResourceService<CategoryModel> _categoryService;

    public TaskController(IResourceService<TaskModel> taskService, IResourceService<CategoryModel> categoryService)
    {
        _taskService = taskService;
        _categoryService = categoryService;
    }

    // Display the list of tasks
    public async Task<IActionResult> Index()
    {
        var tasks = await _taskService.GetResources(); // Get all tasks
        return View(tasks); // Return to the view with tasks list
    }

    // GET: Task/Create
    public async Task<IActionResult> Create()
    {
        var categories = await _categoryService.GetResources(); // Get all categories
        ViewBag.Categories = categories; // Pass categories to the view
        return View();
    }

    // POST: Task/Create
    [HttpPost]
    public async Task<IActionResult> Create(TaskModel task)
    {
        if (ModelState.IsValid)
        {
            await _taskService.Create(task); // Create the task
            return RedirectToAction("Index"); // Redirect to the task list
        }

        // If model state is invalid, return to the create view with errors
        var categories = await _categoryService.GetResources();
        ViewBag.Categories = categories;
        return View(task);
    }

    // GET: Task/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var task = await _taskService.GetResourceById(id); // Get task by id
        if (task == null)
        {
            return NotFound(); // Return 404 if the task is not found
        }

        var categories = await _categoryService.GetResources(); // Get categories for the dropdown
        ViewBag.Categories = categories;
        return View(task); // Return to the edit view with the task data
    }

    // POST: Task/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(int id, TaskModel task)
    {
        if (id != task.Id)
        {
            return NotFound(); // Check if the id matches
        }

        if (ModelState.IsValid)
        {
            await _taskService.Update(task); // Update the task
            return RedirectToAction("Index"); // Redirect to the task list
        }

        var categories = await _categoryService.GetResources();
        ViewBag.Categories = categories;
        return View(task); // Return to the edit view with errors
    }

    // GET: Task/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var task = await _taskService.GetResourceById(id); // Get task by id
        if (task == null)
        {
            return NotFound(); // Return 404 if the task is not found
        }

        return View(task); // Return to the delete view with the task data
    }

    // POST: Task/Delete/5
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var task = await _taskService.GetResourceById(id);
        if (task != null)
        {
            await _taskService.Delete(task); // Delete the task
        }

        return RedirectToAction("Index"); // Redirect to the task list
    }
}
