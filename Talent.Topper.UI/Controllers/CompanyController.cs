using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

using Talent.Topper.UI.Helpers;
using Talent.Topper.UI.Models;
using System.IO;
using System.Configuration;

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

        [HttpGet]
        public ActionResult Save()
        {
            return View();
        }

        [HttpPost]        
        [ValidateAntiForgeryToken]
        public ActionResult Save(CompanyEntity companyEntity)
        {
            //Use Namespace called :  System.IO  
            string FileName = Path.GetFileNameWithoutExtension(companyEntity.ImageFile.FileName);

            //To Get File Extension  
            string FileExtension = Path.GetExtension(companyEntity.ImageFile.FileName);

            //Add Current Date To Attached File Name  
            FileName = DateTime.Now.ToString("MM-dd-yyyy-HH-mm-ss") + "-" + FileName.Trim() + FileExtension;

            //Get Upload path from Web.Config file AppSettings.  
            //string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();
            string UploadPath = Server.MapPath("~/CompanyLogo/");

            //Its Create complete path to store in server.  
            companyEntity.LogoPath = UploadPath + FileName;

            //To copy and save file into server.  
            companyEntity.ImageFile.SaveAs(companyEntity.LogoPath);





            ViewBag.CountryList = CountryHelper.GetCountryData();
            ViewBag.StateByCountryList = StateByCountryHelper.GetStateByCountryData("0");

            bool saveStatus;
            companyEntity.IsActive = true;
            companyEntity.CreatedDate = DateTime.Now;
            companyEntity.CreatedBy = 1;
            companyEntity.is_default = 1;
            companyEntity.ImageFile = null;  //TO UPDATE MODEL SO THAT IT CAN BE SEND AS STRING TO API//
            companyEntity.LogoPath = "~/CompanyLogo/" + FileName; //TO RESET THE FULL PATH ONLY TO FOLDER AND IMAGE NAME//

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