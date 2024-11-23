using Microsoft.AspNetCore.Mvc;
using ToDoMVC.Models;
using ToDoMVC.Services;


public class CategoryController : Controller
{
    private readonly IResourceService<CategoryModel> _categoryService;

    public CategoryController(IResourceService<CategoryModel> categoryService)
    {
        _categoryService = categoryService;
    }

    // Display the list of categories
    public async Task<IActionResult> Index()
    {
        var categories = await _categoryService.GetResources(); // Get all categories
        return View(categories); // Return to the view with the categories list
    }

    // GET: Category/Create
    public IActionResult Create()
    {
        return View(); // Display the form for creating a new category
    }

    // POST: Category/Create
    [HttpPost]
    public async Task<IActionResult> Create(CategoryModel category)
    {
        if (ModelState.IsValid)
        {
            await _categoryService.Create(category); // Create a new category
            return RedirectToAction("Index"); // Redirect to the categories list
        }

        return View(category); // Return to the form with errors
    }

    // GET: Category/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var category = await _categoryService.GetResourceById(id); // Get category by id
        if (category == null)
        {
            return NotFound(); // Return 404 if the category is not found
        }

        return View(category); // Return to the edit view with the category data
    }

    // POST: Category/Edit/5
    [HttpPost]
    public async Task<IActionResult> Edit(int id, CategoryModel category)
    {
        if (id != category.Id)
        {
            return NotFound(); // Return 404 if the id doesn't match
        }

        if (ModelState.IsValid)
        {
            await _categoryService.Update(category); // Update the category
            return RedirectToAction("Index"); // Redirect to the categories list
        }

        return View(category); // Return to the edit view with errors
    }

    // GET: Category/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        var category = await _categoryService.GetResourceById(id); // Get category by id
        if (category == null)
        {
            return NotFound(); // Return 404 if the category is not found
        }

        return View(category); // Return to the delete view with the category data
    }

    // POST: Category/Delete/5
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var category = await _categoryService.GetResourceById(id);
        if (category != null)
        {
            await _categoryService.Delete(category); // Delete the category
        }

        return RedirectToAction("Index"); // Redirect to the categories list
    }
}
