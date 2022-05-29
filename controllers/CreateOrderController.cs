using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jpddoocp.entities;
using jpddoocp.models;

namespace jpddoocp.controllers
{
    class CreateOrderController
    {
        private Order order;
        
        public CreateOrderController(Order order)
        {
            this.order = order;
        }
        public void Save()
        {
            new OrderModel().Save(order);
        }
    }
}
