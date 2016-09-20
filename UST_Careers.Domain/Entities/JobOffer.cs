using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [DataType(DataType.MultilineText)]
        public string description { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string publish_date { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string hash { get; set; }
        public int category_id { get; set; }
        public int location_id { get; set; }
    }
}
