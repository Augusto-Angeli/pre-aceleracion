using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aceleracion.Common
{
    public class JwtOptions
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string SecretKey { get; set; }
    }
}
