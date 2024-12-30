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
        PostContext db = new PostContext();
        public ActionResult index()
        {
            IEnumerable<Post> = db.Posts;
            
            return View();
        }
    }
}
