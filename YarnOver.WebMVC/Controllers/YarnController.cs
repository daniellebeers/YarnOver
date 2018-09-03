using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using YarnOver.Data;
using YarnOver.Models;
using YarnOver.Services;

namespace YarnOver.WebMVC.Controllers
{
    [Authorize]
    public class YarnController : Controller
    {
        // GET: Yarn
        public ActionResult Index()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new YarnService(ownerId);
            var model = service.GetYarns();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(YarnCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateYarnService();

            if (service.CreateYarn(model))
            {
                TempData["SaveResult"] = "Your yarn was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Yarn could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateYarnService();
            var model = svc.GetYarnById(id);

            return View(model);
        }

        private YarnService CreateYarnService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new YarnService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateYarnService();
            var detail = service.GetYarnById(id);
            var model =
                new YarnEdit
                {
                    UserId = detail.UserId,
                    YarnId = detail.YarnId,
                    Color = detail.Color,
                    TotalYardage = detail.TotalYardage,
                    TotalWeight = detail.TotalWeight,
                    Fiber = detail.Fiber,
                    WherePurchased = detail.WherePurchased,

                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, YarnEdit model)
        {
            return View();

            if (!ModelState.IsValid) return View(model);

            if (model.YarnId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateYarnService();

            if (service.UpdateYarn(model))
            {
                TempData["SaveResult"] = "Your yarn was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your yarn could not be updated.");
            return View(model);
        }

       

        public ActionResult Delete(int YarnId)
        {
            var svc = CreateYarnService();
            var model = svc.GetYarnById(YarnId);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateYarnService();

            service.DeleteYarn(id);

            TempData["SaveResult"] = "Your yarn was deleted";

            return RedirectToAction("Index");
        }
    }
}

