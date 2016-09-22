using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UST_Careers.Domain.Entities
{
    public class ApplicationForm_File
    {
        public int id { get; set; }
        public int application_form_id { get; set; }
        public int file_id { get; set; }
    }
}
