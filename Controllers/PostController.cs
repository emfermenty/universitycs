using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Controller]
public class PostController : Controller
{
    public IActionResult Index()
    {
        return View(HomeController.newsList);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        var remove = HomeController.newsList.FirstOrDefault(n => n.Id == id);
        if (remove != null)
        {
            HomeController.newsList.Remove(remove);
        }
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Authors = HomeController.authors;
        ViewBag.Categories = HomeController.categories;
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post post, int selectedAuthorId, int selectedCategoryId)
    {
        if (ModelState.IsValid)
        {
            post.Id = HomeController.newsList.Count > 0 ? HomeController.newsList.Max(n => n.Id) + 1 : 1;
            post.Authorid = selectedAuthorId;
            post.Categoryid = selectedCategoryId;
            HomeController.newsList.Add(post);
            return RedirectToAction("Index", "Post");
        }

        ViewBag.Authors = HomeController.authors;
        ViewBag.Categories = HomeController.categories;
        return View(post);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var post = HomeController.newsList.FirstOrDefault(h => h.Id == id);
        if (post == null)
        {
            return NotFound();
        }

        ViewBag.Authors = HomeController.authors;
        ViewBag.Categories = HomeController.categories;
        return View(post);
    }
}