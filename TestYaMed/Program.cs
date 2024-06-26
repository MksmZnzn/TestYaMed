﻿using TestYaMed.Enums;
using TestYaMed.Models;

namespace YaMed
{

    class Program
    {
        static void Main(string[] args)
        {
            var lera = new Person("Велерия", 22, Gender.Female, 20);
            var maks = new Person("Максим", 25, Gender.Male, 5);

            try
            {                
                lera.PrintInfo();

                var moneyUSD = new Money(5000, Currency.USD);
                var moneyRUB = new Money(50000, Currency.USD);
                var moneyToTransfer = new Money(8000, Currency.USD);
                var moneyZP = new Money(300000, Currency.RUB);
                var moneyPC = new Money(150000, Currency.RUB);
                var moneyGift = new Money(20000, Currency.RUB);

                Console.WriteLine("Добавляю для Валерии 5000 долларов.");
                lera.AddMoney(moneyUSD); 
                
                Console.WriteLine("Добавляю для Валерии 300000 рублей.");
                lera.AddMoney(moneyZP);

                lera.PrintInfo();

                Console.WriteLine("тратим у Валерии 15000 рублей на ПК.");
                lera.SpendMoney(moneyPC);
                lera.PrintInfo();

                Console.WriteLine("Валерия дарит 20000 рублей Максиму, успешный перевод");
                lera.TransferMoneyTo(maks, moneyGift);

                maks.PrintInfo();
                lera.PrintInfo();

                Console.WriteLine("Перевожу Д/С Валерии в размере 8000 долларов Максиму, отлавливаю ошибку");
                lera.TransferMoneyTo(maks, moneyToTransfer);
            }
            catch (Exception ex)
            {                
                Console.WriteLine($"\n Ошибка: \n{ex.Message}\n ");
                lera.PrintInfo();
                maks.PrintInfo();                
            } 
        }
    }
}