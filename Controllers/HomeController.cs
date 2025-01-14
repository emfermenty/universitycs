using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

[Controller]
public class HomeController : Controller
{
    static Category drama = new Category(1, "drama");
    static Category kriminal = new Category(2, "kriminal");
    static Author Dima = new Author(1, "dima", "krytoi");
    static Author shabit = new Author(2, "Хапаев Шабит", "nekrytoi");
    public static List<Category> categories = new List<Category> { drama, kriminal };
    public static List<Author> authors = new List<Author>{ Dima, shabit, };
    public static List<Post> newsList = new List<Post>
    {
        new Post(1, "one", "two", 1, 3, 1),
        new Post(2, "two", "three", 1, 5, 2),
        new Post(3, "three", "four", 2, 7, 1)
    };

    public IActionResult Index()
    {
        System.Diagnostics.Debug.WriteLine($"Количество новостей: {newsList.Count}");
        Console.WriteLine(newsList.Count);
        return View(newsList);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Post news)
    {
        if (ModelState.IsValid)
        {
            news.Id = newsList.Count + 1;
            newsList.Add(news);
            return RedirectToAction("Index");
        }
        return View(news);
    }
}
