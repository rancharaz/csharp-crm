using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jpddoocp.entities;

namespace jpddoocp.models
{
    class CustomerModel:AbstractDbModel
    {
        private Customer customer; 
        public CustomerModel (Customer customer)
        {
            this.customer = customer;
        }
        public void Signup()
        {
            int user_id;
            string sqlQuery = $"INSERT INTO users (username, pwd, usertype_id) VALUES ('{customer.username}','{customer.pwd}',{customer.userType_id});";
            CUquery(sqlQuery);

            user_id = new UserModel().GetUserId(customer.username);

            sqlQuery = $"INSERT INTO customers (firstname, surname, address, email, user_id) VALUES ('{customer.firstname}','{customer.surname}','{customer.address}','{customer.email}',{user_id});";
            CUquery(sqlQuery);
        }
    }
}
