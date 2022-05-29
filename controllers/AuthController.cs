using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jpddoocp.helpers;
using jpddoocp.models;

namespace jpddoocp.controllers
{
    class AuthController
    {
        private string username;
        private string encryptedPassword;
        public AuthController(string username, string pwd)
        {
            this.username = username;
            encryptedPassword = HasherHelper.Hash(pwd);
        }
        public Boolean Authenticate()
        {
           
            AuthModel auth = new AuthModel(username, encryptedPassword);

            return auth.AuthenticateUser();
        }
    }
}
