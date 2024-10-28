using System;
using System.Collections.Generic;
using System.Linq;

namespace DeliveryService
{
    public static class OrderFilter
    {
        public static List<Order> FilterOrders(List<Order> orders, string cityDistrict, DateTime firstDeliveryDateTime)
        {
            DateTime filterEndTime = firstDeliveryDateTime.AddMinutes(30);
            return orders
                .Where(order => order.District.Equals(cityDistrict, StringComparison.OrdinalIgnoreCase) &&
                                order.DeliveryTime >= firstDeliveryDateTime &&
                                order.DeliveryTime <= filterEndTime)
                .ToList();
        }
    }
}
