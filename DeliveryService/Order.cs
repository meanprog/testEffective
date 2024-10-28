using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace DeliveryService
{
    public class Order
    {
        public int OrderId { get; set; }
        public double Weight { get; set; }
        public string? District { get; set; } // Разрешаем null
        public DateTime DeliveryTime { get; set; }

        public static List<Order> LoadOrders(string filePath)
        {
            var orders = new List<Order>();

            try
            {
                // Проверка на существование файла
                if (!File.Exists(filePath))
                {
                    Console.WriteLine($"Файл не найден: {filePath}");
                    return orders; // Возвращаем пустой список, если файл не найден
                }

                foreach (var line in File.ReadLines(filePath))
                {
                    var parts = line.Split(';');
                    if (parts.Length != 4)
                    {
                        Console.WriteLine($"Неправильный формат строки: {line}");
                        continue;
                    }

                    // Парсим данные и обрабатываем возможные ошибки
                    if (!int.TryParse(parts[0], out int orderId) ||
                        !double.TryParse(parts[1], out double weight) ||
                        !DateTime.TryParseExact(parts[3], "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime deliveryTime))
                    {
                        Console.WriteLine($"Ошибка парсинга данных в строке: {line}");
                        continue;
                    }

                    // Создаем и добавляем заказ в список
                    var order = new Order
                    {
                        OrderId = orderId,
                        Weight = weight,
                        District = parts[2],
                        DeliveryTime = deliveryTime
                    };

                    orders.Add(order);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении файла: {ex.Message}");
            }

            return orders;
        }
    }
}
