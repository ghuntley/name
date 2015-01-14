using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    public enum DomainContactType
    {
        Registrant,
        Administrative,
        Billing,
        Technical
    }

    public class CreateDomainRequest
    {
        public List<DomainContact> contacts { get; set; }

        public string domain_name { get; set; }
        public List<string> nameservers { get; set; }

        public int period { get; set; }
    }


    public class DomainContact
    {
        public string address_1 { get; set; }

        public string address_2 { get; set; }

        public string city { get; set; }

        public string country { get; set; }

        public string email { get; set; }

        public string fax { get; set; }

        public string first_name { get; set; }

        public string last_name { get; set; }

        public string organization { get; set; }

        public string phone { get; set; }

        public string state { get; set; }

        public List<DomainContactType> type { get; set; }
        public string zip { get; set; }
    }
}