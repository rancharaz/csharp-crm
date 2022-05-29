using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jpddoocp.entities;

namespace jpddoocp.models
{
    class UserModel:AbstractDbModel
    {
        private User user;

        public UserModel()
        {

        }
        public UserModel(User user )
        {
            this.user = user;
        }
        public int GetUserId(string username)
        {
            string sqlQuery = $"SELECT id FROM users WHERE username='{username}' LIMIT 1";
            return GetInteger(sqlQuery);
        }
    }
}
