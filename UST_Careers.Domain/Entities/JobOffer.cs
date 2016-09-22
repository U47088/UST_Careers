using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UST_Careers.Domain.Entities
{
    public class JobOffer
    {
        [HiddenInput(DisplayValue = false)]
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter a title")]
        public string title { get; set; }
        [Required(ErrorMessage = "Please enter a description")]
        [DataType(DataType.MultilineText)]
        public string description { get; set; }
        public string publish_date { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string hash { get; set; }
        [Required(ErrorMessage = "Please select category")]
        public int category_id { get; set; }
        [Required(ErrorMessage = "Please select location")]
        public int location_id { get; set; }

        [ForeignKey("category_id ")]
        public virtual Category categories { get; set; }

        [ForeignKey("location_id ")]
        public virtual Location locations { get; set; }
    }
}
