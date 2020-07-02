using Competition.Entities;
using Competition.Repositories;
using Competition.ViewModels.Disciplines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Competition.Controllers
{
    public class DisciplineController : Controller
    {
        // GET: Discipline
        public ActionResult Index()
        {
            DisciplineRepository repo = new DisciplineRepository();
            ViewData["disciplines"] = repo.GetAll();

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CreateVM model)
        {
            DisciplineRepository repo = new DisciplineRepository();

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Discipline item = new Discipline();

            item.End = model.End;

            item.DisciplineName = model.DisciplineName;
            item.Start = model.Start;


            repo.Insert(item);

            return RedirectToAction("Index", "Discipline");
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            DisciplineRepository repo = new DisciplineRepository();
            Discipline item = repo.GetById(Id);

            if (item == null)
                return RedirectToAction("Index", "Athletes");
            
            EditVM model = new EditVM();
            model.Id = item.Id;
            model.DisciplineName = item.DisciplineName;
            model.Start = item.Start;
            model.End = item.End;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditVM model)
        {
            if (!ModelState.IsValid)
                return View(model);

            Discipline item = new Discipline();

            item.Id = model.Id;
            item.DisciplineName = model.DisciplineName;
            item.Start = model.Start;
            item.End = model.End;

            DisciplineRepository repo = new DisciplineRepository();
            repo.Update(item);

            return RedirectToAction("Index", "Discipline");
        }

        public ActionResult Delete(int id)
        {
            DisciplineRepository repo = new DisciplineRepository();
            repo.Delete(id);

            return RedirectToAction("Index", "Discipline");
        }
    }
}