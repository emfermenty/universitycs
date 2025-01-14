using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

[Controller]
public class HomeController : Controller
{
    private readonly ApplicationContext _context;

    public HomeController(ApplicationContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        System.Diagnostics.Debug.WriteLine($"Количество новостей: {_context.Posts.Count()}");
        var posts = _context.Posts.ToList();
        return View(posts);
    }

    public IActionResult Create()
    {
        return View();
    }
}
