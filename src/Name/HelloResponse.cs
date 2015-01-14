using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    public class HelloResponse : ResponseBase
    {
        public string service { get; set; }
        public DateTime server_date { get; set; }
        public string version { get; set; }
        public string language { get; set; }
        public string client_ip { get; set; }
    }
}
