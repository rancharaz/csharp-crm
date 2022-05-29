using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using jpddoocp.entities;

namespace jpddoocp.models
{
    class OrderProductsModel:AbstractDbModel
    {
        public void Save(OrderProducts orderProducts)
        {
            foreach (var item in orderProducts.product_idList)
            {

            }
        }
    }
}
