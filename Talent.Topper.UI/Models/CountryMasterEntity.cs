using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Talent.Topper.UI.Models
{
    public class CountryMasterEntity
    {
        [Display(Name = "Country Id")]
        public string ID { get; set; }

        [Display(Name = "Country Name")]
        public string Name { get; set; }

        public DateTime? CreateDate { get; set; }

        
    }
}