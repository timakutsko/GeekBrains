using System;
using System.Collections.Generic;

namespace _4._StoreCheck
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> pricesList = new();
            List<string> productsList = new();
            Console.Write("Введи количество товаров: ");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i=1; i<=count; i++)
            {
                Console.Write($"Введи название товара №{i}: ");
                string product = Console.ReadLine();
                productsList.Add(product);
                Console.Write($"Введи стоимость товара №{i} (округлено до целого числа): ");
                int price = Convert.ToInt32(Console.ReadLine());
                pricesList.Add(price);
            }
            Console.WriteLine();

            var rand = new Random().Next(0, 100);
            Console.WriteLine($"Кассовый чек № {rand}");
            Console.WriteLine();
            Console.WriteLine("ООО 'GeekBrains'");
            Console.WriteLine("Адрес: г. Москва, ул. Ленина, д. 1");
            Console.WriteLine($"Дата прихода: {DateTime.Now}");
            Console.WriteLine();
            Console.WriteLine($"Кассир: {Environment.UserName}");

            int summ = 0;
            for (int i=0; i< count; i++)
            {
                summ += pricesList[i];
                Console.Write($"Товар №{i}: {productsList[i]}. ");
                Console.WriteLine($"Цена: {pricesList[i]} р.");
            }
            Console.WriteLine($"ИТОГО: {summ}");
            Console.WriteLine("СПС ЗА ПОКУПКУ!!!");
        }
    }
}
