using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Talent.Topper.UI.Models
{
    public class BranchMasterEntity
    {
        public int BranchID { get; set; }
        public string BranchName { get; set; }
        public string HOB { get; set; }
        public string BranchAddress { get; set; }
        public string BranchMobileNo { get; set; }
        public string BranchPhoneNo { get; set; }
        public string BranchEmailID { get; set; }
        public string City { get; set; }
        public int? StateID { get; set; }
        public int? CountryID { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? Status { get; set; }
        public string Logo { get; set; }
    }
}