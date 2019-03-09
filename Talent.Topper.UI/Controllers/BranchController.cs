using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Talent.Topper.UI.Helpers;
using Talent.Topper.UI.Models;

namespace Talent.Topper.UI.Controllers
{
    public class BranchController : BaseController
    {
        // GET: Branch

        public ActionResult Index()
        {
            //BranchMasterEntity _BranchMasterEntity = new BranchMasterEntity();
            //return View(_BranchMasterEntity);

            BranchMasterEntity _BranchMasterEntity = new BranchMasterEntity();
            ViewBag.BranchDetails = _BranchMasterEntity;

            ViewBag.CountryList = CountryHelper.GetCountryData();

            ViewBag.StateByCountryList = StateByCountryHelper.GetStateByCountryData("0");

            return View();
        }


        // GET: Company
        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult BranchList()
        {
            List<BranchMasterEntity> _branchEntity = BranchHelper.GetBranchData();
            return View("BranchDetails", _branchEntity);
        }

        public ActionResult Reset()
        {
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName("Index")]
        [ValidateAntiForgeryToken]
        public ActionResult Save(BranchMasterEntity branchEntity)
        {
            ViewBag.BranchDetails = new BranchMasterEntity();

            ViewBag.CountryList = CountryHelper.GetCountryData();
            ViewBag.StateByCountryList = StateByCountryHelper.GetStateByCountryData("0");

            if (ModelState.IsValid)
            {
                //Use Namespace called :  System.IO
                string FileName = Path.GetFileNameWithoutExtension(branchEntity.ImageFile.FileName);

                //To Get File Extension  
                string FileExtension = Path.GetExtension(branchEntity.ImageFile.FileName);

                //Add Current Date To Attached File Name  
                FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                //Get Upload path from Web.Config file AppSettings.  
                //string UploadPath = ConfigurationManager.AppSettings["UserImagePath"].ToString();

                //Its Create complete path to store in server.  
                branchEntity.ImagePath = Path.Combine(Server.MapPath("~/Content/BranchLogo"),
                                           Path.GetFileName(FileName)); // UploadPath + FileName;

                //To copy and save file into server.  
                branchEntity.ImageFile.SaveAs(branchEntity.ImagePath);


                bool saveStatus = false;
                saveStatus = BranchHelper.SaveBranchData(branchEntity, saveStatus);
                ViewBag.SaveStatus = saveStatus;
            }

            return View(branchEntity);
        }
    }
}