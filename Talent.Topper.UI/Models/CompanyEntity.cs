using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Talent.Topper.UI.Models
{
    public partial class CompanyList
    {
        public long ID { get; set; }
        public string CompanyName { get; set; }
        public string CEOName { get; set; }
        public string WebsiteUrl { get; set; }
        public string LogoPath { get; set; }
        public Nullable<long> Contact_Id { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
    }
    public class CompanyEntity
    {
        public long ID { get; set; }

        [Required]
        [Display(Name = "Companay Name")]
        public string CompanyName { get; set; }

        [Display(Name = "CEO Name")]
        public string CEOName { get; set; }

        [Display(Name = "Website URL")]
        public string WebsiteUrl { get; set; }
        [Display(Name = "Compeny Logo")]
        public string LogoPath { get; set; }

        [Display(Name = "Status")]
        public bool? IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public int CreatedBy { get; set; }

        [Display(Name = "Comapany Type")]
        public string CompanyType { get; set; }

        public int RoleId { get; set; }

        [Display(Name = "Mobile")]
        public string MobileNo { get; set; }

        [Display(Name = "Phone")]
        public string PhoneNo { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string Password { get; set; }

        [Required]
        [Display(Name = "Full Address")]
        public string addressline { get; set; }

        [Display(Name = "Country")]
        public int CountryID { get; set; }

        [Display(Name = "State")]
        public int StateID { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }

        public int is_default { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}