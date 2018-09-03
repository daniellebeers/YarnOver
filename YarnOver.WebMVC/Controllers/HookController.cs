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
    public class HookController : Controller
    {
        
        public ActionResult Index()
        {
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new HookService(ownerId);
            var model = service.GetHooks();

            return View(model);
        }

        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HookCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateHookService();

            if (service.CreateHook(model))
            {
                TempData["SaveResult"] = "Your hook was added.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Hook could not be added.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateHookService();
            var model = svc.GetHookById(id);

            return View(model);
        }

        private HookService CreateHookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HookService(userId);
            return service;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateHookService();
            var detail = service.GetHookById(id);
            var model =
                new HookEdit
                {
                   // HookId = detail.HookId,
                    NumberSize = detail.NumberSize,
                    LetterSize = detail.LetterSize,
                    Material = detail.Material,
                };
            return View(model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, HookEdit model)
        {
            return View();

            if (!ModelState.IsValid) return View(model);

            if (model.HookId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateHookService();

            if (service.UpdateHook(model))
            {
                TempData["SaveResult"] = "Your hook was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your hook could not be updated.");
            return View(model);
        }

        
        public ActionResult Delete(int HookId)
        {
            var svc = CreateHookService();
            var model = svc.GetHookById(HookId);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateHookService();

            service.DeleteHook(id);

            TempData["SaveResult"] = "Your note was deleted";

            return RedirectToAction("Index");
        }


    }
}
    
