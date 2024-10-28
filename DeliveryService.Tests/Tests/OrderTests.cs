using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace DeliveryService.Tests
{
    public class OrderTests
    {

        [Fact]
        public void LoadOrders_EmptyFile_ReturnsEmptyList()
        {
            string tempFilePath = Path.GetTempFileName();

            var orders = Order.LoadOrders(tempFilePath);

            // Assert: проверяем, что для пустого файла возвращается пустой список
            Assert.Empty(orders);

            // Удаляем временный файл
            File.Delete(tempFilePath);
        }
    }
}
