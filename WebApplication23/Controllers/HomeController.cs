using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication23.Models;
namespace WebApplication23.Controllers
{
    
    public class HomeController : Controller
        
    {
        testingEntities db = new testingEntities();
        static List<Depart> obj = new List<Depart>();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]//annotation
        public ActionResult Index(abc b)
        {
            db.abcs.Add(b);
           int s= db.SaveChanges();
            ModelState.Clear();

            if (s>0)
            {
                ViewBag.msg = "inserted successfully";
            }
            else
            {
                ViewBag.msg = "inserted unsuccessfully";
            }
           
            return RedirectToAction("Select","Home");
        }
        public ActionResult Select()
        {
            return View(obj.ToList());
        }
        public ActionResult Delete(int id)
        
        {
           var t= obj.Where(a => a.id == id).FirstOrDefault();
            obj.Remove(t);
            return RedirectToAction("Select","Home");
        }
        public ActionResult Edit(int id)
        {
            var t = obj.Where(a => a.id == id).FirstOrDefault();
            return View(t);
        }
        [HttpPost]
        public ActionResult Edit(Depart o)
        {
            var t = obj.Where(a => a.id ==o.id).FirstOrDefault();
            t.name = o.name;
            t.password = o.password;
            t.age = o.age;
            return RedirectToAction("Select","Home");
        }
    }
}