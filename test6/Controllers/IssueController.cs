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
    [Authorize(Roles = "Admin,Developer")]
    public class IssueController : Controller
    {
        private readonly ApplicationDbContext _db;

        public IssueController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Issue> objList = _db.Issue;
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
        public IActionResult Create(Issue obj)
        {
            _db.Issue.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
       
        //GET-EDIT
        public IActionResult Edit(string ProjectName)
        {
            if (ProjectName == null)
            {
                return NotFound();
            }
            var obj = _db.Issue.Find(ProjectName);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST-EDIT
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Issue obj)
        {
            _db.Issue.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
