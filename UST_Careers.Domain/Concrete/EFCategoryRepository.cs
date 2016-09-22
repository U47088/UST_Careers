using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UST_Careers.Domain.Abstract;
using UST_Careers.Domain.Entities;

namespace UST_Careers.Domain.Concrete
{
    public class EFCategoryRepository: ICategoryRepository
    {
        private EFDbContext context = new EFDbContext();
        public IEnumerable<Category> Categories
        {
            get { return context.Categories; }
        }
    }
}
