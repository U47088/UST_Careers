using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UST_Careers.Domain.Abstract;
using UST_Careers.Domain.Entities;

namespace UST_Careers.WebUI.Controllers
{
    public class JobOfferController : Controller
    {
        private IJobOfferRepository repository;

        public JobOfferController(IJobOfferRepository jobOffersRepository)
        {
            this.repository = jobOffersRepository;
        }
        public ActionResult Index()
        {
            return View(repository.JobOffers);
        }
        public ViewResult Create()
        {
            return View("Edit", new JobOffer());
        }
        public ViewResult Edit(int jobOfferId)
        {
            JobOffer jobOffer = repository.JobOffers.FirstOrDefault(j => j.id == jobOfferId);
            return View(jobOffer);
        }
        [HttpPost]
        public ActionResult Edit(JobOffer jobOffer)
        {
            if (ModelState.IsValid)
            {
                repository.SaveJobOffer(jobOffer);
                TempData["message"] = string.Format("Job Offer has been saved");
                return RedirectToAction("Index");
            }
            else
            {
                TempData["message"] = string.Format("There were some errors");
                return View(jobOffer);
            }
        }

        public ActionResult Delete(int jobOfferId)
        {
            JobOffer deletedProduct = repository.DeleteProduct(jobOfferId);
            if (deletedProduct != null)
            {
                TempData["message"] = string.Format("Job Offer was deleted");
            }
            return RedirectToAction("Index");
        }
    }
}