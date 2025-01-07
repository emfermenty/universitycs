using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Controller]
public class HomeController : Controller
{
    public static List<Post> newsList = new List<Post>
    {
        new Post(1, "one", "two", 3),
        new Post(2, "two", "three", 5),
        new Post(3, "three", "four", 7),
    };

    public IActionResult Index()
    {
        System.Diagnostics.Debug.WriteLine($"���������� ��������: {newsList.Count}");
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
        if (ModelState.IsValid) // �������� �� ���������� ������
        {
            news.Id = newsList.Count + 1;
            newsList.Add(news);
            return RedirectToAction("Index");
        }
        return View(news); // ���� ������ �� �������, ���������� �� �� �����
    }
}




/*
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        DataBaseContext db = new DataBaseContext();
        public ActionResult index()
        {
            
            
            return View();
        }
    }
}*/
