using Microsoft.AspNetCore.Mvc;
using TransportWeb.Data;
using TransportWeb.Models;

namespace TransportWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly ApplicationDBContext db;

        public PostController(ApplicationDBContext db)
        {
            this.db = db;
        }


        public IActionResult Index()
        {
            IEnumerable<Post> posts = db.Posts;
            
            return View(posts);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index", "Post");
            }
            return View(post);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = db.Posts.Find(id);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Update(post);
                db.SaveChanges();
                return RedirectToAction("Index", "Post");
            }
            return View(post);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = db.Posts.Find(id);

            if (post == null)
            {
                return NotFound();
            }
            return View(post);
        }

        //Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = db.Posts.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            db.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index","Post");
        }

        public IActionResult Message(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var post = db.Posts.Find(id);

            if (post == null)
            {
                return NotFound();
            }
            
            return View(post);
        }
    }
}
