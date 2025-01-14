using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationContext _context;
        public AuthorController(ApplicationContext context)
        {
            _context = context;
        }
        public ActionResult Index() {
            var author = _context.Authors.ToList();
            return View(author); 
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
                _context.Authors.Add(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.id == id);
            if (author != null)
            {
                _context.Authors.Remove(author);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var author = _context.Authors.FirstOrDefault(a => a.id == id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public IActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                _context.Authors.Update(author);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }
        private Author GetAuthorId(int id)
        {
            Author author = _context.Authors.FirstOrDefault(a => a.id == id);
            return author;
        }
    }
}
