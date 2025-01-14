using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

[Controller]
public class PostController : Controller
{
    private readonly ApplicationContext _context;

    public PostController(ApplicationContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var posts = _context.Posts.ToList(); 
        return View(posts);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var post = _context.Posts.FirstOrDefault(n => n.Id == id); 
        if (post != null)
        {
            _context.Posts.Remove(post); 
            _context.SaveChanges(); 
        }
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Authors = _context.Authors.ToList(); 
        ViewBag.Categories = _context.Categories.ToList(); 
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post post, int selectedAuthorId, int selectedCategoryId)
    {
        if (ModelState.IsValid)
        {
            post.Authorid = selectedAuthorId;
            post.Categoryid = selectedCategoryId; 
            _context.Posts.Add(post); 
            _context.SaveChanges(); 
            return RedirectToAction("Index");
        }

        ViewBag.Authors = _context.Authors.ToList(); 
        ViewBag.Categories = _context.Categories.ToList(); 
        return View(post);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var post = _context.Posts.FirstOrDefault(h => h.Id == id); 
        if (post == null)
        {
            return NotFound();
        }

        ViewBag.Authors = _context.Authors.ToList();
        ViewBag.Categories = _context.Categories.ToList(); 
        return View(post);
    }
}