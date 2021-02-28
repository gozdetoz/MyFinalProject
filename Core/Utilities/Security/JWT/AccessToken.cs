using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //Token ve bitiş zamanı degerleri
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
