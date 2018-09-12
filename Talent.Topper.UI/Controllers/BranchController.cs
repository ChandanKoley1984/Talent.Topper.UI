using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Talent.Topper.UI.Models;

namespace Talent.Topper.UI.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch

        public ActionResult Index()
        {
            BranchMasterEntity _BranchMasterEntity = new BranchMasterEntity();
            return View(_BranchMasterEntity);
        }
        // GET: Branch
        public ActionResult BranchList()
        {
            List<BranchMasterEntity> _BranchMasterEntitys = new List<BranchMasterEntity>();
            BranchMasterEntity _BranchMasterEntity;
            for (int i = 0; i < 10; i++)
            {
                _BranchMasterEntity = new BranchMasterEntity();
                _BranchMasterEntity.CompanyID = 1;
                _BranchMasterEntity.BranchName = "TestBranch";
                _BranchMasterEntity.HOB = "Chandan";
                _BranchMasterEntitys.Add(_BranchMasterEntity);
            }

            return View("BranchDetails", _BranchMasterEntitys);
        }
    }
}