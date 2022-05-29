using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace jpddoocp.models
{
    class AuthModel:AbstractDbModel
    {
        private readonly String username;
        private readonly String encryptedPassword;
        public AuthModel(String username, String encryptedPassword)
        {
            this.username = username;
            this.encryptedPassword = encryptedPassword;
        }
        private Boolean IsUserMember()
        {
            int count;
            string sqlQuery = $"SELECT count(id) FROM users WHERE username ='{username}' LIMIT 1;";
            count = GetInteger(sqlQuery);
            return (count == 1) ? true : false;
        }
        private Boolean IsPasswordCorrect()
        {
            int count;
            string sqlQuery = $"SELECT count(id) FROM users WHERE username ='{username}' AND pwd='{encryptedPassword}'  LIMIT 1;";
            count = GetInteger(sqlQuery);
            return (count == 1) ? true : false;
        }

        public Boolean AuthenticateUser()
        {
            return IsUserMember() && IsPasswordCorrect();
        }
      
    }
}
