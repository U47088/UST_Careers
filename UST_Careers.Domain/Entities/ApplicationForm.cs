using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UST_Careers.Domain.Entities
{
    public class ApplicationForm
    {
        public int id { get; set; }
        public string user_name { get; set; }
        public string user_surname { get; set; }
        public string user_email { get; set; }
        public Guid confirmation_guid { get; set; }
        public int status { get; set; }
        public int job_offer_id { get; set; }
    }
}
