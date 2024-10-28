using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace DeliveryService
{
    class Program
    {
        static void Main(string[] args)
        {
            // Чтение параметров из аргументов командной строки
            if (args.Length < 3)
            {
                Console.WriteLine("Необходимы параметры: <Район> <Время первой доставки> <Путь к логам> <Путь к результатам>");
                return;
            }

            string cityDistrict = args[0];
            DateTime firstDeliveryDateTime;
            if (!DateTime.TryParse(args[1], out firstDeliveryDateTime))
            {
                Console.WriteLine("Некорректный формат времени.");
                return;
            }

            string deliveryLogPath = args[2];
            string deliveryOrderPath = args[3];

            Logger logger = new Logger(deliveryLogPath);

            try
            {

                var orders = Order.LoadOrders("data.txt");

                var filteredOrders = OrderFilter.FilterOrders(orders, cityDistrict, firstDeliveryDateTime);

                File.WriteAllText(deliveryOrderPath, JsonConvert.SerializeObject(filteredOrders, Formatting.Indented));

                logger.Log("Фильтрация завершена успешно.");
            }
            catch (FileNotFoundException ex)
            {
                logger.Log($"Файл не найден: {ex.Message}");
            }
            catch (UnauthorizedAccessException ex)
            {
                logger.Log($"Нет доступа к файлу: {ex.Message}");
            }
            catch (Exception ex)
            {
                logger.Log($"Неизвестная ошибка: {ex.Message}");
            }
        }
    }
}
