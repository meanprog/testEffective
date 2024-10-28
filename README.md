# Delivery Service Console Application

## Описание

Это консольное приложение для службы доставки, которое фильтрует заказы в зависимости от количества обращений в конкретном районе города и времени обращения. Оно предоставляет возможность загрузки заказов из текстового файла, фильтрации по заданным параметрам и ведения логирования основных операций.

![image](https://github.com/user-attachments/assets/f00e5056-20e8-4458-a221-22ed79a7a4f3)
![image](https://github.com/user-attachments/assets/fa761a8c-c00e-4187-b63a-2ebfb2725657)


## Структура проекта

Проект состоит из следующих компонентов:

- **DeliveryService**: основной проект, содержащий логику обработки заказов и фильтрации.
- **DeliveryService.Tests**: проект, содержащий тесты для проверки функциональности приложения.


## Структура проекта
Приложение ожидает следующие параметры:

_cityDistrict: район доставки.
_firstDeliveryDateTime: время первой доставки.
_deliveryLog: путь к файлу с логами.
_deliveryOrder: путь к файлу с результатами выборки.

"Central" "2024-10-28 14:30:00" "path/to/log.txt" "path/to/result.txt"

## Проект содержит несколько тестов, которые проверяют:

Загрузку заказов: корректная обработка валидных данных и игнорирование некорректных строк.
Фильтрацию заказов: правильная фильтрация по заданным параметрам.

![image](https://github.com/user-attachments/assets/12f4c7fe-5bc7-4b62-b55f-8e8ccf4116a2)


## Паттерны проектирования и лучшие практики
В проекте применяются следующие паттерны проектирования и лучшие практики:

KISS (Keep It Simple, Stupid): код написан с целью быть простым и понятным для разработчиков.
SOLID: принципы SOLID применяются для обеспечения чистой архитектуры и улучшения читаемости кода.
Чтение и валидация входных данных: приложение обрабатывает и валидирует входные данные, чтобы избежать сбоев.

## Логирование
Приложение ведет логирование основных операций, что позволяет отслеживать состояние и поведение приложения в процессе работы. Логи можно сохранить в файл или в базу данных.
