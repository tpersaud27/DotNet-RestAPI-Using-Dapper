using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestAPI.Domain
{
    // This class will have all of the data columns from the DB. They will be exactly the same as the DB columns
    public class Developer
    {
        public int Id { get; set; }
        public string DeveloperName { get; set; }
        public string DeveloperEmail { get; set; }
        public string Department { get; set; }

    }
}
