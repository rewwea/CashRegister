using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.WriteLine("Добро пожаловать в магазин новогодних товаров!");

        // Товары
        Dictionary<string, (decimal price, int stock)> products = new Dictionary<string, (decimal, int)>()
        {
            { "Ёлка", (1000m, 5) },
            { "Гирлянда", (500m, 10) },
            { "Игрушка", (200m, 15) },
            { "Хлопушка", (100m, 20) }
        };

                decimal total = 0;
        while (true)
        {
            Console.WriteLine("\nСписок товаров:");
            foreach (var item in products)
            {
                Console.WriteLine($"{item.Key} — {item.Value.price} руб. (в наличии: {item.Value.stock})");
            }

            Console.Write("Введите название товара (или 'стоп' для завершения): ");
            string input = Console.ReadLine();
            if (input.ToLower() == "стоп") break;

            if (!products.ContainsKey(input))
            {
                Console.WriteLine("Товара нет в списке.");
                continue;
            }

            Console.Write("Введите количество: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Некорректное количество.");
                continue;
            }

            var (price, stock) = products[input];
            if (qty > stock)
            {
                Console.WriteLine("Недостаточно товара на складе.");
                continue;
            }

            products[input] = (price, stock - qty);
            decimal subtotal = price * qty;
            Console.WriteLine($"Добавлено в корзину: {qty} x {input} = {subtotal} руб.");
            total += subtotal;
        }

        // Скидка
        if (total > 2000)
        {
            Console.WriteLine("Применена скидка 10% за покупку от 2000 руб.");
            total *= 0.9m;
        }

        Console.WriteLine($"\nИтого к оплате: {total} руб.");
    }
}