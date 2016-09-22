using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UST_Careers.Domain.Abstract;
using UST_Careers.Domain.Entities;
using UST_Careers.WebUI.Models;

namespace UST_Careers.WebUI.Controllers
{
    public class JobOfferController : Controller
    {
        private IJobOfferRepository repository;
        private ILocationRepository locationRepo;
        private ICategoryRepository categoryRepo;

        public JobOfferController(IJobOfferRepository jobOffersRepository, ILocationRepository locationRepository,
            ICategoryRepository categoryRepo)
        {
            this.repository = jobOffersRepository;
            this.locationRepo = locationRepository;
            this.categoryRepo = categoryRepo;
        }
        public ActionResult Index()
        {
            return View(repository.JobOffers);
        }
        public ViewResult Create()
        {
            JobOfferViewModel viewModel = new JobOfferViewModel(new JobOffer(), new SelectList(categoryRepo.Categories, "id", "name"),
                new SelectList(locationRepo.Locations, "id",  "city"));
            return View("Edit", viewModel);
        }
        public ViewResult Edit(int jobOfferId)
        {
            JobOffer jobOffer = repository.JobOffers.FirstOrDefault(j => j.id == jobOfferId);
            JobOfferViewModel viewModel = new JobOfferViewModel(jobOffer, new SelectList(categoryRepo.Categories, "id", "name"),
                new SelectList(locationRepo.Locations, "id", "city"));
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(JobOfferViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                repository.SaveJobOffer(viewModel.JobOffer);
                TempData["successMessage"] = string.Format("Job Offer has been saved");
                return RedirectToAction("Index");
            }
            else
            {
                TempData["errorMessage"] = string.Format("Invalid data provided to form");
                viewModel.CategorySelectListItems = new SelectList(categoryRepo.Categories, "id", "name");
                viewModel.LocationSelectListItems = new SelectList(locationRepo.Locations, "id", "city");
                return View(viewModel);
            }
        }

        public ActionResult Delete(int jobOfferId)
        {
            JobOffer deletedJobOffer = repository.DeleteJobOffer(jobOfferId);
            if (deletedJobOffer != null)
            {
                TempData["successMessage"] = string.Format("Job Offer was deleted");
            }
            return RedirectToAction("Index");
        }
    }
}