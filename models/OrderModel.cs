using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jpddoocp.entities;
using System.Data;

namespace jpddoocp.models
{
    class OrderModel:AbstractDbModel
    {
       
        
        public OrderModel()
        {
            
        }
        public void Save(Order order)
        {  
            string sqlQuery = $"INSERT INTO orders (delivery_mode_id, customer_id) VALUES ({order.deliveryModeId},{order.customerId});";
            CUquery(sqlQuery);
        }
      
    }
}
