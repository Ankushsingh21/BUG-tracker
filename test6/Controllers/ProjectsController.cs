using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test6.Data;
using test6.Models;

namespace test6.Controllers
{
    [Authorize(Roles = WC.AdminRole)]
    public class ProjectsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProjectsController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Projects> objList = _db.Projects;
            return View(objList);
        }
        //GET-CREATE
        public IActionResult Create()
        {
            return View();
        }
        //POST-CREATE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Projects obj)
        {
            _db.Projects.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET-EDIT
        public IActionResult Edit(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _db.Projects.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Projects obj)
        {
            _db.Projects.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        //GET-DELETE
        public IActionResult Delete(string Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _db.Projects.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST-DELETE
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(string Id)
        {
            var obj = _db.Projects.Find(Id);
            _db.Projects.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
