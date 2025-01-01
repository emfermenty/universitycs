using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

public class AuthorController : Controller
{
    private readonly DataBaseContext _context;
    public AuthorController(DataBaseContext context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        var authors = _context.Authors.ToList();
        return View(authors);
    }
}