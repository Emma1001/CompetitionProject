using Competition.Entities;
using Competition.Repositories;
using Competition.ViewModels.Athletes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Competition.Controllers
{
    public class AthletesController : Controller
    {
        // GET: Athletes
        public ActionResult Index()
        {
            AthleteRepository repo = new AthleteRepository();
            TeamRepository repoTeams = new TeamRepository();

            ViewData["teams"] = repoTeams.GetAll();
            ViewData["athletes"] = repo.GetAll();

            return View();
        }

        public ActionResult Create()
        {
            TeamRepository repoTeams = new TeamRepository();
            ViewData["teams"] = repoTeams.GetAll();

            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateVM model, int teamId)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            

            AthleteRepository repo = new AthleteRepository();
            TeamRepository repoTeams = new TeamRepository();
            Athlete item = new Athlete();
            
            Team team = repoTeams.GetById(teamId);

            item.TeamId = team.Id;
            item.Name = model.Name;


            repo.Insert(item);

            return RedirectToAction("Index", "Athletes");
        }

        [HttpGet]
        public ActionResult AddDiscipline(int athleteId)
        {
            ManagerDbContext context = new ManagerDbContext();
            AthleteRepository athleteRepository = new AthleteRepository();
            DisciplineRepository disciplineRepository = new DisciplineRepository();

            DisciplineVM disciplineVM = new DisciplineVM
            {
                Athlete = athleteRepository.GetById(athleteId),

                Shared = context.AthleteToDisciplines
                .Where(i => i.AthleteId == athleteId)
                .ToList(),

                Disciplines = disciplineRepository.GetAll()
            };

            return View(disciplineVM);
        }

        [HttpPost]
        public ActionResult AddDiscipline(int athleteId, int disciplineId)
        {
            AthleteToDiscipline athleteToDiscipline = new AthleteToDiscipline();
            athleteToDiscipline.AthleteId = athleteId;
            athleteToDiscipline.DisciplineId = disciplineId;

            ManagerDbContext context = new ManagerDbContext();
            context.AthleteToDisciplines.Add(athleteToDiscipline);
            context.SaveChanges();

            return RedirectToAction("AddDiscipline", "Athletes", new { athleteId = athleteId });
        }

        public ActionResult Details(int athleteId)
        {
            ManagerDbContext context = new ManagerDbContext();

            DetailsVM model = new DetailsVM();
            model.Athlete = context.Athletes
                .Where(i => i.Id == athleteId)
                .FirstOrDefault();

            model.DisciplinesList = context.AthleteToDisciplines
                .Where(i => i.AthleteId == athleteId)
                .ToList();

            model.Team = context.Teams
                .Where(i => i.Id == model.Athlete.TeamId)
                .FirstOrDefault();

            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int athleteId)
        {
            AthleteRepository repo = new AthleteRepository();
            Athlete item = repo.GetById(athleteId);

            if(item == null)
                return RedirectToAction("Index", "Athletes");


            TeamRepository repoTeams = new TeamRepository();
            ViewData["teams"] = repoTeams.GetById(item.TeamId);

            ViewData["team"] = repoTeams.GetAll();

            item.Team = ((Team)ViewData["teams"]);

            EditVM model = new EditVM();
            model.Id = item.Id;
            model.Name = item.Name;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model, int teamId)
        {
            if (!ModelState.IsValid)
                return View(model);

            Athlete item = new Athlete();
            TeamRepository repoTeams = new TeamRepository();
            ViewData["team"] = repoTeams.GetAll();
            ViewData["teams"] = repoTeams.GetById(teamId);

            item.Id = model.Id;
            item.TeamId = ((Team)ViewData["teams"]).Id;
            item.Name = model.Name;
            item.Team = (Team)ViewData["teams"];

            AthleteRepository repo = new AthleteRepository();
            repo.Update(item);

            return RedirectToAction("Index", "Athletes");
        }

        public ActionResult Delete(int athleteId)
        {
            AthleteRepository repo = new AthleteRepository();
            repo.Delete(athleteId);

            return RedirectToAction("Index", "Athletes");
        }
        
    }
}