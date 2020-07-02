using Competition.Entities;
using Competition.Repositories;
using Competition.ViewModels.Teams;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Competition.Controllers
{
    public class TeamController : Controller
    {
        private ManagerDbContext context = null;
        // GET: Team
        public ActionResult Index()
        {
            TeamRepository repo = new TeamRepository();
            ViewData["teams"] = repo.GetAll();

            return View();
        }
        

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Team item = new Team();

            item.Country = model.Country;

            TeamRepository repo = new TeamRepository();
            repo.Insert(item);

            return RedirectToAction("Index", "Team");
        }
    }
}