using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Talent.Topper.UI.Models
{
    public class CompanyEntity
    {
        [Required]
        [Display(Name = "Companay Name")]
        public string CompanayName { get; set; }
        [Required]
        [Display(Name = "Full Address")]
        public string FullAddress { get; set; }
        [Required]
        [Display(Name = "Country Code")]
        public string CountryCode { get; set; }
        
        [Display(Name = "Mobile")]
        public string MobileNo { get; set; }
        
        [Display(Name = "Phone")]
        public string PhoneNo { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        
        [Display(Name = "Website URL")]
        public string WebsiteURL { get; set; }
        
        public string Logo { get; set; }
        
        [Display(Name = "CEO Name")]
        public string CEOName { get; set; }
        
        [Display(Name = "Country")]
        public string CountryID { get; set; }
        
        [Display(Name = "State")]
        public string StateID { get; set; }
        
        [Display(Name = "City")]
        public string City { get; set; }
        
        [Display(Name = "Comapany Type")]
        public string ComapanyType { get; set; }       
        
        public string Password { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Status")]
        public int? IsActive { get; set; }
    }
}