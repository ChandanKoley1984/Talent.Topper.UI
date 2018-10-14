using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult CompanyList(CompanyEntity CompanyEntity)
        {
           List<CompanyEntity> _companyEntity = CompanyHelper.GetCompanyData();
            return View("CompanyDetails", _companyEntity);
        }

        public ActionResult Save(CompanyEntity companyEntity)
        {
            return new EmptyResult();
        }
    }
}