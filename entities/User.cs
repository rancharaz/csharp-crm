using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jpddoocp.entities
{
    class User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string pwd { get; set; }
        public int userType_id { get; set; }
    }
}
