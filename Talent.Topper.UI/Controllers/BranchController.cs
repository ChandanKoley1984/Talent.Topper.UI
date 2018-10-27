using System;
using System.Collections.Generic;
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
            BranchMasterEntity _BranchMasterEntity = new BranchMasterEntity();
            return View(_BranchMasterEntity);
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
            bool saveStatus = false;
            saveStatus = BranchHelper.SaveBranchData(branchEntity, saveStatus);
            ViewBag.SaveStatus = saveStatus;
            return View(branchEntity);
        }
    }
}