using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UST_Careers.Domain.Entities
{
    public class Categories
    {
        public int id { get; set; }
        public int parent_id { get; set; }
        public string name { get; set; }
    }
}
