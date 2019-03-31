using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Talent.Topper.UI.Models
{
    public class BranchMasterEntity
    {
        public string id { get; set; }
        [Required]
        [Display(Name = "Companay Name")]
        public int CompanyID { get; set; }
        [Required]
        [Display(Name = "Branch Name")]
        public string BranchName { get; set; }
        [Display(Name = "HOB Name")]
        public string HOB { get; set; }
        [Display(Name = "Address")]
        public string BranchAddress { get; set; }
        [Display(Name = "Mobile Number")]
        public string BranchMobileNo { get; set; }
        [Display(Name = "Phone Number")]
        public string BranchPhoneNo { get; set; }
        [Required]
        [Display(Name = "Email ID")]
        public string BranchEmailID { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string StateID { get; set; }
        [Display(Name = "Country")]
        public string CountryID { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? Status { get; set; }
        [Display(Name = "Branch Logo")]
        public string ImagePath { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
        public string Password { get; set; }
    }
}