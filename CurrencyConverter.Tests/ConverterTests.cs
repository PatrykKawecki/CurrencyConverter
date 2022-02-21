using NUnit.Framework;
using System;

namespace CurrencyConverter.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        [TestCase("HACKER")]
        public void TryGetCurrencyThatNotInTheSystem(string currency)
        {
            //Arannge 
            var converter = new CurrencyConverter();
            //Act and Assert
            Assert.Throws<ArgumentNullException>(() => converter.GetValue(currency));
        }

        [TestCase(3,0)]
        public void TryMultipleWithZeroAmount(float val, float amount)
        {
            //Arannge 
            var converter = new CurrencyConverter();
            //Act and Assert
            Assert.Throws<ArgumentException>(() => converter.Calculate(val, amount));
        }

        [TestCase(0, 3)]
        public void TryMultipleWithZeroValue(float val, float amount)
        {
            //Arannge 
            var converter = new CurrencyConverter();
            //Act and Assert
            Assert.Throws<ArgumentException>(() => converter.Calculate(val, amount));
        }

        [TestCase("USD")]
        public void TryGetCurrencyThatIsInTheSystem(string currency)
        {
            //Arrange
            var converter = new CurrencyConverter();
            //Act
            var result = converter.GetValue(currency);
            //Assert
            Assert.IsNotNull(result);
        }

        [TestCase("USD",3,2)]
        public void TryGetCurrencyThatIsInTheSystem(string currency, float price, float amout)
        {
            //Arrange
            var converter = new CurrencyConverter();
            //Act
            var result = converter.Calculate(price, amout);
            //Assert
            Assert.IsNotNull(result);

        }

        [TestCase("USD", ExpectedResult = 1.1354f)]
        [TestCase("JPY", ExpectedResult = 130.59f)]
        [TestCase("BGN", ExpectedResult = 1.9558f)]
        [TestCase("CZK", ExpectedResult = 24.337f)]
        [TestCase("DKK", ExpectedResult = 7.4382f)]
        [TestCase("GBP", ExpectedResult = 0.83425f)]
        [TestCase("HUF", ExpectedResult = 356.37f)]
        [TestCase("PLN", ExpectedResult = 4.5201f)]
        [TestCase("RON", ExpectedResult = 4.9453f)]
        [TestCase("SEK", ExpectedResult = 10.5796f)]
        [TestCase("CHF", ExpectedResult = 1.0452f)]
        [TestCase("ISK", ExpectedResult = 140.80f)]
        [TestCase("NOK", ExpectedResult = 10.1465f)]
        [TestCase("HRK", ExpectedResult = 7.5355f)]
        [TestCase("RUB", ExpectedResult = 86.2815f)]
        [TestCase("TRY", ExpectedResult = 15.4678f)]
        [TestCase("AUD", ExpectedResult = 1.5754f)]
        [TestCase("BRL", ExpectedResult = 5.8435f)]
        [TestCase("CAD", ExpectedResult = 1.4424f)]
        [TestCase("CNY", ExpectedResult = 7.1840f)]
        [TestCase("HKD", ExpectedResult = 8.8566f)]
        [TestCase("IDR", ExpectedResult = 16304.49f)]
        [TestCase("ILS", ExpectedResult = 3.6276f)]
        [TestCase("INR", ExpectedResult = 84.6525f)]
        [TestCase("KRW", ExpectedResult = 1356.45f)]
        [TestCase("MXN", ExpectedResult = 23.0270f)]
        [TestCase("MYR", ExpectedResult = 4.7528f)]
        [TestCase("NZD", ExpectedResult = 1.6896f)]
        [TestCase("PHP", ExpectedResult = 58.403f)]
        [TestCase("SGD", ExpectedResult = 1.5255f)]
        [TestCase("THB", ExpectedResult = 36.435f)]
        [TestCase("ZAR", ExpectedResult = 17.0858f)]
        public float GetValueShouldReturnCorrectFloatValue(string currency)
        {
            var converter = new CurrencyConverter();
            return converter.GetValue(currency);
        }

    }
}
