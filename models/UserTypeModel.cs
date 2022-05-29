using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jpddoocp.models
{
    class UserTypeModel:AbstractDbModel
    {
      
        public int GetUserTypeId(string type)
        {
            string sqlQuery = $"SELECT id FROM usertypes WHERE usertype='{type}' LIMIT 1";
            return GetInteger(sqlQuery);
        }
    }
}
