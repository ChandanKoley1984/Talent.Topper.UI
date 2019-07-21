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
            ViewBag.companyDetails = _companyEntity;

            ViewBag.CountryList = CountryHelper.GetCountryData();

            ViewBag.StateByCountryList = StateByCountryHelper.GetStateByCountryData("0");

            return View();
        }
        public ActionResult Edit(int id)
        {
            List<CompanyEntity> _companyEntity = CompanyHelper.GetCompanyEditData(id);

            return View("index",_companyEntity.FirstOrDefault());
        }
        // GET: Company
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult CompanyList()
        {
            List<CompanyList> _companyEntity = CompanyHelper.GetCompanyListData();
            return View("CompanyDetails", _companyEntity);
        }

        public ActionResult Reset()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public ActionResult Save(CompanyEntity companyEntity)
        {
            bool saveStatus;
            companyEntity = CompanyHelper.SaveCompanyData(companyEntity, out saveStatus);
            ViewBag.SaveStatus = saveStatus;
            return View("Index",companyEntity);
        }
        public ActionResult SearchCompanyList(string name)
        {
            List<CompanyEntity> _companyEntity = CompanyHelper.SearchCompanyList(name);
            return PartialView("CompanyDetailsFilter", _companyEntity);
        }
    }
}