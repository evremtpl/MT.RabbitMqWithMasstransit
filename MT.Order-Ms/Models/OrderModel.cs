using MT.Messaging;

namespace MT.Order_Ms.Models
{
    public class OrderModel : IOrderCommand
    {
        public int OrderID { get; set; }
        public string OrderCode { get; set; }
    }
}
