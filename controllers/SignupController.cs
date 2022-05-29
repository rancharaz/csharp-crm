using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jpddoocp.entities;
using jpddoocp.models;
using jpddoocp.helpers;
namespace jpddoocp.controllers
{
    class SignupController
    {
        private Customer customer;
        public SignupController(string firstname, string surname, string address, string username, string pwd, string email)
        {
            customer = new Customer();
            customer.firstname = firstname;
            customer.surname = surname;
            customer.address = address;
            customer.username = username;
            customer.pwd = HasherHelper.Hash(pwd);
            customer.email = email;
            customer.userType_id= new UserTypeModel().GetUserTypeId("customer");
        }
        public void Signup()
        {
            new CustomerModel(customer).Signup();
        }
    }
   
}
