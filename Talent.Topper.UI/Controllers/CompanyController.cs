using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Talent.Topper.UI.Models;

namespace Talent.Topper.UI.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            CompanyEntity _companyEntity = new CompanyEntity();
            return View(_companyEntity);
        }
        // GET: Company
        public ActionResult CompanyList()
        {
            List<CompanyEntity> _companyEntitys = new List<CompanyEntity>();
            CompanyEntity _companyEntity;
            for (int i=0;i<10;i++)
            {
                _companyEntity = new CompanyEntity();
                _companyEntity.CompanayName = "Test";
                _companyEntity.Email = "Test@test.com";
                _companyEntity.WebsiteURL = "www.test.com";
                _companyEntitys.Add(_companyEntity);
            }

            return View("CompanyDetails", _companyEntitys);
        }
    }
}