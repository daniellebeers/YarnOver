using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YarnOver.Models;
using YarnOver.Services;

namespace YarnOver.WebMVC.Controllers
{
    [Authorize]
    public class ProjectController : Controller
    {
        // GET: Project
        public ActionResult Index()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(ownerId);
            var model = service.GetProjects();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateProjectService();

            if (service.CreateProject(model))
            {
                TempData["SaveResult"] = "Your project was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Project could not be added.");

            return View(model);
        }

          

        public ActionResult Details(int id)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(id);

            return View(model);
        }

        private ProjectService CreateProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ProjectService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateProjectService();
            var detail = service.GetProjectById(id);
            var model =
                new ProjectEdit
                {

                    UserId = detail.UserId,
                    ProjectId = detail.ProjectId,
                    ProjectName = detail.ProjectName,
                    PatternLocation = detail.PatternLocation,
                    ProjectYarn = detail.ProjectYarn,
                };

            return View(model);
        }


        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ProjectEdit model)
        {
            return View();

            if (!ModelState.IsValid) return View(model);

            if (model.ProjectId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateProjectService();

            if (service.UpdateProject(model))

            {
                TempData["SaveResult"] = "Your project was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your project could not be updated.");
            return View(model);
        }

        public ActionResult Delete(int ProjectId)
        {
            var svc = CreateProjectService();
            var model = svc.GetProjectById(ProjectId);

            return View(model);
        }
        
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateProjectService();

            service.DeleteProject(id);

            TempData["SaveResult"] = "Your project was deleted";

            return RedirectToAction("Index");
        }


    }
}
