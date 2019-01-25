using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Talent.Topper.UI.Models
{
    public class StateByCountryEntity
    {
        [Display(Name = "State Id")]
        public string ID { get; set; }
        public string CountryId { get; set; }

        [Display(Name = "Country Name")]
        public string StateName { get; set; }

        public DateTime? CreateDate { get; set; }

       
    }
}