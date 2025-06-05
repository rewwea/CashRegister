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

        // TODO: выбор товара, количество, подсчет суммы
    }
}