using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Talent.Topper.UI.Helpers;
using Talent.Topper.UI.Models;

namespace Talent.Topper.UI.Controllers
{
    public class IDGenerationController : Controller
    {
        // GET: IDGeneration
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Reset()
        {
            return RedirectToAction("Index");
        }

        // GET: ID
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult GeneratedIDs()

        {
            List<IDGeneration> iDGenerationEntityList = IDGenerationHelper.GetGeneratedIDs();
            return View("IDDetails", iDGenerationEntityList);
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult Save(IDGeneration iDGenerationEntity)
        {
            bool saveStatus = false;
            saveStatus = IDGenerationHelper.SaveGeneratedID(iDGenerationEntity, saveStatus);
            ViewBag.SaveStatus = saveStatus;
            return View(new IDGeneration());
        }
    }
}