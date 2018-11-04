using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Talent.Topper.UI.Models
{
    public class IDGeneration
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Prefix")]
        public string Prefix { get; set; }
        [Required]
        [Display(Name = "Prefix Seperate")]
        public string PrefixSeperate { get; set; }

        [Display(Name = "Suffix")]
        public string Suffix { get; set; }

        [Display(Name = "Suffix Seperate")]
        public string SuffixSeperate { get; set; }
        [Display(Name = "Number")]
        public string Number { get; set; }

        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public DateTime? UpdateDate { get; set; }

        public int UpdateBy { get; set; }
    }
}