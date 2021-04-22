using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test6.Models;
using test6.Data;
using Microsoft.AspNetCore.Authorization;

namespace test6.Controllers
{
    [Authorize(Roles="Admin,Developer")]
    public class ManageRolesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ManageRolesController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<ManageRoles> objList = _db.ManageRoles;
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
        public IActionResult Create(ManageRoles obj)
        {
            _db.ManageRoles.Add(obj);
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
            var obj = _db.ManageRoles.Find(Id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ManageRoles obj)
        {
            _db.ManageRoles.Update(obj);
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
            var obj = _db.ManageRoles.Find(Id);
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
            var obj = _db.ManageRoles.Find(Id);
            _db.ManageRoles.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
