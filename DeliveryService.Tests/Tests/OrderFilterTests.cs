using System;
using System.Collections.Generic;
using Xunit;

namespace DeliveryService.Tests
{
    public class OrderFilterTests
    {
        [Fact]
        public void FilterOrders_ReturnsCorrectOrders()
        {
            // Создаем несколько заказов
            var orders = new List<Order>
            {
                new Order { OrderId = 1, District = "Central", DeliveryTime = new DateTime(2024, 10, 28, 14, 30, 0) },
                new Order { OrderId = 2, District = "Central", DeliveryTime = new DateTime(2024, 10, 28, 14, 45, 0) },
                new Order { OrderId = 3, District = "North", DeliveryTime = new DateTime(2024, 10, 28, 14, 45, 0) }
            };

            // Выполняем фильтрацию
            var result = OrderFilter.FilterOrders(orders, "Central", new DateTime(2024, 10, 28, 14, 30, 0));

            // Проверяем, что фильтрация выполнена правильно
            Assert.Equal(2, result.Count);
            Assert.All(result, order => Assert.Equal("Central", order.District));
        }

        [Fact]
        public void FilterOrders_IgnoresOrdersOutsideTimeRange()
        {
            var orders = new List<Order>
            {
                new Order { OrderId = 1, District = "Central", DeliveryTime = new DateTime(2024, 10, 28, 14, 20, 0) },
                new Order { OrderId = 2, District = "Central", DeliveryTime = new DateTime(2024, 10, 28, 15, 10, 0) }
            };

            var result = OrderFilter.FilterOrders(orders, "Central", new DateTime(2024, 10, 28, 14, 30, 0));

            Assert.Empty(result);
        }
    }
}
