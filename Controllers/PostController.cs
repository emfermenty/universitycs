using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Controller]
public class PostController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Delete(int id)
    {
        var remove = HomeController.newsList.FirstOrDefault(n => n.Id == id);
        if(remove != null)
        {
            HomeController.newsList.Remove(remove);
        }
        return RedirectToAction("index");
    }

    //[HttpPost]
    public IActionResult Create()
    {
        return View();
    }
}