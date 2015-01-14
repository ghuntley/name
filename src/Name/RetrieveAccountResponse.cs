using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    public class RetrieveAccountResponse : ResponseBase
    {
        public string username { get; set; }
        public DateTime create_date { get; set; }
        public long domain_count { get; set; }
        public decimal account_credit { get; set; }

        public List<AccountContact> contacts { get; set; } 
    }
}
