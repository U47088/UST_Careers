using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UST_Careers.Domain.Abstract;
using UST_Careers.Domain.Entities;


namespace UST_Careers.Domain.Concrete
{
    public class EFLocationRepository: ILocationRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Location> Locations
        {
            get { return context.Locations; }
        }
    }
}
