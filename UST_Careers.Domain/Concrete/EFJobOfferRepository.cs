using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UST_Careers.Domain.Abstract;
using UST_Careers.Domain.Entities;

namespace UST_Careers.Domain.Concrete
{
    public class EFJobOfferRepository: IJobOfferRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<JobOffer> JobOffers
        {
            get { return context.JobOffers; }
        }

        public void SaveJobOffer(JobOffer jobOffer)
        {
            if (jobOffer.id == 0)
            {
                jobOffer.publish_date = DateTime.Now.ToString("dd-MM-yyyy HH:mm");
                jobOffer.hash = jobOffer.GetHashCode().ToString();               
                context.JobOffers.Add(jobOffer);
            }
            else
            {
                JobOffer dbEntry = context.JobOffers.Find(jobOffer.id);
                if (dbEntry != null)
                {
                    dbEntry.category_id = jobOffer.category_id;
                    dbEntry.description = jobOffer.description;
                    dbEntry.location_id = jobOffer.location_id;
                    dbEntry.title = jobOffer.title;
                    dbEntry.publish_date = jobOffer.publish_date;
                }
                else
                {
                    throw new System.NullReferenceException("JobOffer not found");
                }
            }
            context.SaveChanges();
        }
        public JobOffer DeleteJobOffer(int id)
        {
            JobOffer dbEntry = context.JobOffers.Find(id);
            if (dbEntry != null)
            {
                context.JobOffers.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
