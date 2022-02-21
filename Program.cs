using System;
using System.Globalization;
using System.Xml;

namespace CurrencyConverter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Euro currency converter");            
            string[] availableCurrency = CurrencyConverter.GetTags();
            Console.WriteLine("This is the list of Available Currencies");
            Console.WriteLine(string.Join(",", availableCurrency).ToUpper());
            Console.WriteLine("Select the currency you wish to change your EURO");
            string current = Console.ReadLine().ToUpper();

            var getVal = new CurrencyConverter();

            float val = getVal.GetValue(current);
            Console.WriteLine("Insert your amount that you want to change");
            float amount = float.Parse(Console.ReadLine());
            var result = getVal.ChangeValue(val, amount);
            Console.WriteLine(result);





        }
    }
}
