using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UST_Careers.Domain.Entities;

namespace UST_Careers.WebUI.Models
{
    public class JobOfferViewModel
    {
        public JobOffer JobOffer { get; set; }
        public IEnumerable<SelectListItem> CategorySelectListItems { get; set; }
        public IEnumerable<SelectListItem> LocationSelectListItems { get; set; }

        public JobOfferViewModel()
        { }
        public JobOfferViewModel(JobOffer jobOffer, SelectList categories, SelectList locations)
        {
            JobOffer = jobOffer;
            CategorySelectListItems = categories;
            LocationSelectListItems = locations;
        }
    }
}