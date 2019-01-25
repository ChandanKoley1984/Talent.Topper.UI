using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Talent.Topper.UI.Helpers;
using Talent.Topper.UI.Models;

namespace Talent.Topper.UI.Controllers
{
    public class StateByCountryController : Controller
    {
        // GET: StateByCountry
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult StateByCountryList(string Id)
        {
            ViewBag.StateByCountryList = StateByCountryHelper.GetStateByCountryData(Id);           

            return Json(new SelectList(ViewBag.StateByCountryList.ToArray(), "ID", "StateName"), JsonRequestBehavior.AllowGet);
        }
    }
}