
namespace jpddoocp.entities
{
    class Order
    {
        public int deliveryModeId { get; set; }
        public int customerId { get; set; }

        public string status { get; set; }

        public string orderDate { get; set; }
    }
}
