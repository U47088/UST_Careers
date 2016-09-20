using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UST_Careers.Domain.Entities;

namespace UST_Careers.Domain.Abstract
{
    public interface IJobOfferRepository
    {
        IEnumerable<JobOffer> JobOffers { get; }
        void SaveJobOffer(JobOffer jobOffer);
        JobOffer DeleteProduct(int productID);
    }
}
