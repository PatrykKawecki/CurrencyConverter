using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Globalization;

namespace CurrencyConverter
{
    /// <summary>
    /// 
    /// </summary>
    public class CurrencyConverter
    {
        string _fileLoaction { get; set; }

        public CurrencyConverter(string fileLoaction = @"XmlFiles\referenceRates.xml")
        {
            _fileLoaction = fileLoaction;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private XmlReader LoadDataFromXml()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location), _fileLoaction);

            if(!File.Exists(path))
            {
                throw new FileNotFoundException("File not found", path);
            }

            XmlReader xmlReader = XmlReader.Create(path);
            return xmlReader;
        }

        /// <summary>
        /// Get list of current currency from xml file
        /// </summary>
        /// <returns></returns>
        public List<string> GetTags()
        {
            var readXml = LoadDataFromXml();
            List<string> currencyTags = new List<string>();
            while (readXml.Read())
            {
                if (IsElementCubeAndHasAttribute(readXml))
                {
                    string currency = readXml.GetAttribute("currency");
                    currencyTags.Add(currency);
                }

            }
            return currencyTags;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="current"></param>
        /// <returns></returns>
        public float GetValue(string currency)
        {
            var readXml = LoadDataFromXml();
            while (readXml.Read())
            {
                if (IsElementCubeAndHasAttribute(readXml) && (readXml.GetAttribute(EnviromentSetting.Currency) == currency))
                {
                    float rate = float.Parse(readXml.GetAttribute(EnviromentSetting.Rate)
                        .ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
                    return rate;
                }
            }
            throw new ArgumentNullException($"Currency not found {currency}!");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public float Calculate(float val, float amount)
        {
            if(amount <= 0)
            {
                throw new ArgumentException("Amount can not be less then 0");
            }

            if (val <= 0)
            {
                throw new ArgumentException("Value can not be less then 0");
            }

            float result = amount * val;

            return result;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="readXml"></param>
        /// <returns></returns>
        private bool IsElementCubeAndHasAttribute(XmlReader readXml)
        {
            return (readXml.NodeType == XmlNodeType.Element) && (readXml.Name == EnviromentSetting.Cube) && readXml.HasAttributes;
        }
    }
}
