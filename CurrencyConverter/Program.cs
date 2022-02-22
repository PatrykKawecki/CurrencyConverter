using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var converter = new CurrencyConverter();
            void CurrencyCalculator()
            {
                Console.WriteLine("Euro currency converter");
                List<string> availableCurrency = converter.GetTags();
                Console.WriteLine("This is the list of Available Currencies");
                Console.WriteLine(string.Join(",", availableCurrency).TrimStart(','));
                Console.WriteLine("Select the currency you wish to change your EURO");
                string current = Console.ReadLine().ToUpper();
                
                float rate = converter.GetRate(current);
                Console.WriteLine("Insert your amount that you want to change. If you give to much decimal places, converter will round it");
                try
                {
                    float amount = float.Parse(Console.ReadLine());
                    var result = converter.Calculate(rate, amount);
                    Console.WriteLine($"{MathF.Round(amount, 2)} [EUR] = {result} [{current}]");
                }
                catch (FormatException)
                {
                    throw new FormatException("amount must be a number with correct format!");
                }
                Console.WriteLine("If you want to use converter again, please press <Enter>");
                var key = Console.ReadKey();
                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    CurrencyCalculator();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Thank you for using this converter, have a nice day!");
                }
            }
            CurrencyCalculator();

        }
    }
}
