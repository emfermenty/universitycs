using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller
{
    public IActionResult Index()
    {
        return View(HomeController.categories);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var remove = HomeController.categories.FirstOrDefault(n => n.Id == id);
        if (remove != null)
        {
            HomeController.categories.Remove(remove);
        }
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Category cate)
    {
        if (ModelState.IsValid)
        {
            cate.Id = HomeController.categories.Count > 0 ? HomeController.categories.Max(n => n.Id) + 1 : 1;
            HomeController.categories.Add(cate);
            return RedirectToAction("Index", "Category");
        }
        return View(cate);
    }

    public IActionResult Posts(int categoryId)
    {
        var postsInCategory = HomeController.newsList.Where(p => p.Categoryid == categoryId).ToList();
        ViewBag.CategoryId = categoryId; // Передаем идентификатор категории в представление
        return View(postsInCategory);
    }
}