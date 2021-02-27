using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestApp.Controllers
{
    public class TestsController : Controller
    {
        public TestAppDBContext db;
        public TestsController(TestAppDBContext context)
        {
            db = context;
        }
        [Authorize]
        public IActionResult Menu()
        {
            return View(db.Tests.Include(x => x.Questions));
        }
        public IActionResult Test(int id)
        {
            Test _test = db.Tests.Include(x => x.Questions).FirstOrDefault(x => x.Id == id);
            return View(_test);
        }
        [HttpPost]
        public IActionResult Test(IFormCollection collection)
        {
            var ans = (collection["ans"]).Select(x => int.Parse(x)).ToArray();
            Test _test = db.Tests.Include(x => x.Questions).FirstOrDefault(x => x.Id == int.Parse(collection["model"]));
            var _que = db.Questions.Where(x => x.Testid == _test.Id).ToArray();
            Completedtest c = new Completedtest() {Date = DateTime.Now, Testid = _test.Id, 
                Personid=db.People.FirstOrDefault(x => x.Email == User.Identity.Name).Id};
            db.Completedtests.Add(c);
            db.SaveChanges();
            c = db.Completedtests.OrderByDescending(p => p.Id).FirstOrDefault();
            for (int i = 0; i < ans.Length; i++)
            {
                Answer a = new Answer() { Completedtestid = c.Id, Questionid = _que[i].Id, Value=ans[i]};
                db.Answers.Add(a);
            }
            db.SaveChanges();
            return RedirectToAction(nameof(Menu));
        }
        [Authorize]
        public IActionResult Results()
        {
            return View(db.Completedtests
                .Include(x => x.Answers)
                .ThenInclude(x => x.Question)
                .Include(x => x.Test)
                .Include(x => x.Person));
        }
        public IActionResult Statistics(int? id)
        {
            if (id == null)
                id = 1;
            var i = db.Tests
                .Include(x => x.Completedtests)
                .ThenInclude(x => x.Answers)
                .Include(x => x.Questions)
                .FirstOrDefault(x => x.Id == id);
            return View(i);
        }
    }
}
