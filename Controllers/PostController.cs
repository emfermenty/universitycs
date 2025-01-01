using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class PostsController : Controller
{
    private readonly DataBaseContext _context;

    public PostsController(DataBaseContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var posts = _context.Posts.Include(p => p.posts_category).ToList();
        return View(posts);
    }

    public IActionResult Create()
    {
        // Логика для создания поста
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post post, int[] selectedCategory)
    {
        if (ModelState.IsValid)
        {
            post.posts_category = selectedCategory.Select(p => new PostCategoryes { PostID = p }).ToList();
            _context.Posts.Add(post);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(post);
    }

    public IActionResult Delete(int id)
    {
        var post = _context.Posts.Find(id);
        if (post != null)
        {
            _context.Posts.Remove(post);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}