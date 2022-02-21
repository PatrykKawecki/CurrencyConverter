using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CurrencyConverter
{
    public class CurrencyConverter
    {
        public static string[] GetTags()
        {
            string[] currencyTags = new string[] {"eur", "usd", "jpy", "bgn", "czk", "dkk", "gbp", "huf", "ltl", "lvl"
            , "pln", "ron", "sek", "chf", "nok", "hrk", "rub", "try", "aud", "brl", "cad", "cny", "hkd", "idr", "ils"
            , "inr", "krw", "mxn", "myr", "nzd", "php", "sgd", "zar"};

            return currencyTags;
        }

        public float GetValue(string current)
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"XmlFiles\referenceRates.xml");
            XmlReader xmlReader = XmlReader.Create(path);
            while (xmlReader.Read())
            {

                if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "Cube") && (xmlReader.GetAttribute("currency") == current))
                {
                    if (xmlReader.HasAttributes)
                    {                           
                        float rate = float.Parse(xmlReader.GetAttribute("rate").Replace('.', ','));
                        return rate;
                    }
                }
            }
            return 0; 
        }

        public float ChangeValue(float val, float amount)
        {
            float result = amount * val;
            return result;
        }
    }
}
