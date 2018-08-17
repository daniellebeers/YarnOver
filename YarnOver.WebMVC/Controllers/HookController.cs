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
        // GET: Hook
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HookService(userId);
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
            if (ModelState.IsValid) return View(model);
            
            var service = CreateHookService();

            if (service.CreateHook(model))
            {
                return RedirectToAction("Index");
            };

            return View(model);
        }

        private HookService CreateHookService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new HookService(userId);
            return service;
        }
    }
}
    
