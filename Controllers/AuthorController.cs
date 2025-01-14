using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AuthorController : Controller
    {
        public ActionResult Index() {  
            return View(HomeController.authors); 
        }
        public ActionResult Details(int id)
        {
            Author author = GetAuthorId(id);
            if (author == null)
            {
                return NotFound(); 
            }
            return View(author); 
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                author.id = HomeController.authors.Count > 0 ? HomeController.authors.Max(n => n.id) + 1 : 1;
                HomeController.authors.Add(author);
                return RedirectToAction("Index", "Author");
            }
            return View(author);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var remove = HomeController.authors.FirstOrDefault(n => n.id == id);
            if (remove != null)
            {
                HomeController.authors.Remove(remove);
            }
            return RedirectToAction("Index", "Author");
        }

        public ActionResult Edit(int id)
        {
            return View();
        }
        private Author GetAuthorId(int id)
        {
            Author author = HomeController.authors.FirstOrDefault(a => a.id == id);
            return author;
        }
    }
}
