using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Response_Models
{
    public class AuthTokenResponse
    {
        public string Token { get; set; }
        public int ExpiryInSeconds { get; set; }
    }
}
