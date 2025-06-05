using System;
using System.Collections.Generic;

namespace CashRegisterApp
{
    class Program
    {
        static void Main()
        {
            // Задание 1
            CheckNumberInRange();

            // Задание 2
            RunCashRegister();
        }

        static void CheckNumberInRange()
        {
            Console.WriteLine("Задание 1: Проверка числа в диапазоне");

            Console.Write("Введите нижнюю границу: ");
            int min = int.Parse(Console.ReadLine());

            Console.Write("Введите верхнюю границу: ");
            int max = int.Parse(Console.ReadLine());

            int number;
            do
            {
                Console.Write("Введите число: ");
                number = int.Parse(Console.ReadLine());

                if (number < min || number > max)
                {
                    Console.WriteLine("Число вне диапазона. Попробуйте снова.");
                }

            } while (number < min || number > max);

            Console.WriteLine($"Число {number} в диапазоне [{min}, {max}]");
        }

        static void RunCashRegister()
        {
            Console.WriteLine("\nЗадание 2: Кассовый аппарат");

            Dictionary<string, (decimal price, int stock)> products = new Dictionary<string, (decimal, int)>
            {
                { "Ёлка", (1000m, 5) },
                { "Гирлянда", (500m, 10) },
                { "Игрушка", (200m, 15) },
                { "Хлопушка", (100m, 20) }
            };

            decimal totalRevenue = 0;

            while (true)
            {
                Console.WriteLine("\nНовый клиент. Нажмите Enter или напишите 'выход' для завершения.");
                string input = Console.ReadLine();
                if (input.ToLower() == "выход") break;

                decimal sale = ServeClient(products);
                totalRevenue += sale;

                Console.WriteLine($"Покупка завершена. Сумма: {sale} руб.");
            }

            Console.WriteLine($"\nОбщая выручка: {totalRevenue} руб.");
        }

        static decimal ServeClient(Dictionary<string, (decimal price, int stock)> products)
        {
            decimal total = 0;

            while (true)
            {
                Console.WriteLine("\nДоступные товары:");
                foreach (var item in products)
                {
                    Console.WriteLine($"{item.Key} — {item.Value.price} руб. (осталось: {item.Value.stock})");
                }

                Console.Write("Введите товар (или 'стоп'): ");
                string input = Console.ReadLine();
                if (input.ToLower() == "стоп") break;

                if (!products.ContainsKey(input))
                {
                    Console.WriteLine("Такого товара нет.");
                    continue;
                }

                Console.Write("Введите количество: ");
                if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
                {
                    Console.WriteLine("Неверное количество.");
                    continue;
                }

                var (price, stock) = products[input];
                if (qty > stock)
                {
                    Console.WriteLine("Недостаточно на складе.");
                    continue;
                }

                products[input] = (price, stock - qty);
                decimal subtotal = price * qty;
                total += subtotal;
                Console.WriteLine($"Добавлено: {qty} x {input} = {subtotal} руб.");
            }

            if (total > 2000)
            {
                Console.WriteLine("Применена скидка 10%!");
                total *= 0.9m;
            }

            return total;
        }
    }
}