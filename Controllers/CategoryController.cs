using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller {
    private readonly DataBaseContext _context;
    public CategoryController(DataBaseContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var categoryes = _context.Categories.ToList();
        return View(categoryes);
    }
}
