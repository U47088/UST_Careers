using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UST_Careers.Domain.Entities
{
    public class File
    {
        public int id { get; set; }
        public string hash { get; set; }
        public string upload_date { get; set; }
    }
}
