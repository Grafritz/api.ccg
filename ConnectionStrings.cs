using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brain.Dev.GStock.Data
{
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Secret { get; set; }
        public string Password { get; set; }
        public bool Trusted_Connection { get; set; } = true;
        public bool MultipleActiveResultSets { get; set; } = true;
        public string DefaultConnectionString => $"server={Server};user={UserId};password={Password};database={Database}";

        //Server=localhost\\SQLEXPRESS;Database=NationalWindows_db_DEV;User Id = sa; Password=123@pass;Trusted_Connection=True;MultipleActiveResultSets=true;
    }
}
