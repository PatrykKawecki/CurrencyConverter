using System;
using System.Collections.Generic;
using System.Linq;
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
            XmlReader xmlReader = XmlReader.Create("C:\\Users\\Patryk\\Desktop\\ATOS\\CurrencyConverter\\XMLFile1.xml");
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
