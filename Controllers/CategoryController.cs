using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller
{
    private readonly ApplicationContext _context;
    public CategoryController(ApplicationContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var categories = _context.Categories.ToList();
        return View(categories);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var category = _context.Categories.Find(id);
        //var remove = HomeController.categories.FirstOrDefault(n => n.Id == id);
        if (category != null)
        {
            _context.Categories.Remove(category);
            _context.SaveChanges();
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
            _context.Categories.Add(cate);
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }
        return View(cate);
    }
    public IActionResult Posts(int categoryId)
    {
        var postsincategory = _context.Posts.Where(p => p.Categoryid == categoryId).ToList();
        ViewBag.CategoryId = categoryId; 
        return View(postsincategory);
    }
}