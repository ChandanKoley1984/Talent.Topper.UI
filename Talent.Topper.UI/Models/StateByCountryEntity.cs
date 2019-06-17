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
        public int ID { get; set; }
        [Display(Name = "State Name")]
        public string NAME { get; set; }
        public Nullable<int> STATUS { get; set; }
        public Nullable<int> COUNTRY_ID { get; set; }


    }
}