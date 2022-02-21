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

            Console.WriteLine("Euro currency converter");            
            List<string> availableCurrency = converter.GetTags();
            Console.WriteLine("This is the list of Available Currencies");
            Console.WriteLine(string.Join(",", availableCurrency).TrimStart(','));
            Console.WriteLine("Select the currency you wish to change your EURO");
            string current = Console.ReadLine().ToUpper();

            float val = converter.GetValue(current);
            Console.WriteLine("Insert your amount that you want to change");
            float amount = float.Parse(Console.ReadLine());
            var result = converter.Calculate(val, amount);
            Console.WriteLine($"{amount} EUR = {result} {current}");

        }
    }
}
