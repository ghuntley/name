using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name
{
    public class LoginResponse : ResponseBase
    {
        public string session_token { get; set; }
    }
}
