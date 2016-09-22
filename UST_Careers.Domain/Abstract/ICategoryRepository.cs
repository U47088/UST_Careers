using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UST_Careers.Domain.Entities;

namespace UST_Careers.Domain.Abstract
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
