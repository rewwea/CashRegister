using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите нижнюю границу диапазона: ");
        int min = int.Parse(Console.ReadLine());

        Console.Write("Введите верхнюю границу диапазона: ");
        int max = int.Parse(Console.ReadLine());

        int number;
        do
        {
            Console.Write("Введите число в заданном диапазоне: ");
            number = int.Parse(Console.ReadLine());

            if (number < min || number > max)
            {
                Console.WriteLine("Число вне диапазона. Попробуйте снова.");
            }
        } while (number < min || number > max);

        Console.WriteLine($"Число {number} находится в диапазоне [{min}, {max}]");
    }
}