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
    /// This class contains essential methods to exchange currency rates
    /// </summary>
    public class CurrencyConverter
    {
        string _fileLoaction { get; set; }

        public CurrencyConverter(string fileLoaction = @"XmlFiles\referenceRates.xml")
        {
            _fileLoaction = fileLoaction;
        }

        /// <summary>
        /// Private method to read Xml document
        /// </summary>
        /// <returns>returns XmlReader instance using the stream to xml data</returns>
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
        /// Get list of currency from xml file
        /// </summary>
        /// <returns>This method return list of strings from cube currency</returns>
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
        /// Get relevant rate from given currency
        /// </summary>
        /// <param name="currency"> This is name of currency </param>
        /// <returns>returns conversation rate between Euro and Currency in a floating point number</returns>
        public float GetRate(string currency)
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
            throw new ArgumentException("Invalid currency!");
        }

        /// <summary>
        /// Calculate amout of euro to amout of chosen currency
        /// </summary>
        /// <param name="rate">Conversation rate between Euro and Currency</param>
        /// <param name="amount">amount of euro</param>
        /// <returns>exchange result</returns>
        public float Calculate(float rate, float amount)
        {

            if (amount <= 0)
            {
                throw new ArgumentException("Amount can not be less or equal to 0");
            }

            if (rate <= 0)
            {
                throw new ArgumentException("Value can not be less or equal to 0");
            }

            float result = MathF.Round(amount, 2) * rate;
            return MathF.Round(result, 2); 

        }


        /// <summary>
        /// private method in order not to repeat the code
        /// </summary>
        /// <param name="readXml">XmlReader instance that read xml</param>
        /// <returns>conditional instruction to method GetTags and GetRate</returns>
        private bool IsElementCubeAndHasAttribute(XmlReader readXml)
        {
            return (readXml.NodeType == XmlNodeType.Element) && (readXml.Name == EnviromentSetting.Cube) && readXml.HasAttributes;
        }
    }
}
