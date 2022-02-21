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
        static XmlReader LoadDataFromXml()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), @"XmlFiles\referenceRates.xml");
            XmlReader xmlReader = XmlReader.Create(path);
            return xmlReader;
        }
        public static List<string> GetTags()
        {
            var readXml = LoadDataFromXml();
            List<string> currencyTags = new List<string>();
            while (readXml.Read())
            {

                if ((readXml.NodeType == XmlNodeType.Element) && (readXml.Name == "Cube") && readXml.HasAttributes)
                {
                    string currency = readXml.GetAttribute("currency");
                    currencyTags.Add(currency);
                }

            }
            //string[] currencyTags = new string[] {"eur", "usd", "jpy", "bgn", "czk", "dkk", "gbp", "huf", "ltl", "lvl"
            //, "pln", "ron", "sek", "chf", "nok", "hrk", "rub", "try", "aud", "brl", "cad", "cny", "hkd", "idr", "ils"
            //, "inr", "krw", "mxn", "myr", "nzd", "php", "sgd", "zar"};

            return currencyTags;
        }

        public float GetValue(string current)
        {
            var readXml = LoadDataFromXml();
            while (readXml.Read())
            {

                if ((readXml.NodeType == XmlNodeType.Element) && (readXml.Name == "Cube") && (readXml.GetAttribute("currency") == current) && readXml.HasAttributes)
                {
                    float rate = float.Parse(readXml.GetAttribute("rate").Replace('.', ','));
                    return rate;
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
