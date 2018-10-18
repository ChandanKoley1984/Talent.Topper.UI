using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

using Talent.Topper.UI.Helpers;
using Talent.Topper.UI.Models;

namespace Talent.Topper.UI.Controllers
{
    public class CompanyController : BaseController
    {
        // GET: Company

        public ActionResult Index()
        {
            CompanyEntity _companyEntity = new CompanyEntity();
            //Company Enity Render from database 

            return View(_companyEntity);
        }
        // GET: Company
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult CompanyList()
        {
            List<CompanyEntity> _companyEntity = CompanyHelper.GetCompanyData();
            return View("CompanyDetails", _companyEntity);
        }

        [ChildActionOnly]
        public ActionResult Reset()
        {
            return RedirectToAction("Index");
        }
       
        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CompanyEntity companyEntity)
        {
            bool saveStatus = false;
            saveStatus = CompanyHelper.SaveCompanyData(companyEntity, saveStatus);
            ViewBag.SaveStatus = saveStatus;            
            return View(companyEntity);
        }
        
    }
}