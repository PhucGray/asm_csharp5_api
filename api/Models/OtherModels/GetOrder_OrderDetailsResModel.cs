using System.Collections.Generic;

namespace api.Models.OtherModels
{
    public class GetOrder_OrderDetailsResModel
    {
        public OrderModel Order { get; set; }
        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
