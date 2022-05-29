using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jpddoocp.entities
{
    class OrderProducts
    {
        public int order_id { get; set; }
        public int [] product_idList { get; set; }
        public int [] qtyList { get; set; }
    }
}
