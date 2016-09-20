using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UST_Careers.Domain.Entities;

namespace UST_Careers.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<JobOffer> JobOffers { get; set; }
    }
}
