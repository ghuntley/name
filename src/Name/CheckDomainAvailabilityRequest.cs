using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{

    public class CheckDomainAvailabilityRequest
    {
        public string keyword { get; set; }
        public string services { get; set; }

        public List<string> tlds { get; set; }
    }
}