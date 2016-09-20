using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UST_Careers.Domain.Entities
{
    public class Location
    {
        public int id { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string house_number { get; set; }
    }
}
