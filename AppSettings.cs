using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brain.Dev.GStock.Data
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public string[] OriginsCorsPolicyUrls { get; set; }
        public string[] MethodsCorsPolicy { get; set; }
        public string[] HeadersCorsPolicy { get; set; }
    }
}
