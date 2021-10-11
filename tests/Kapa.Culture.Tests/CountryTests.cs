using System;
using Xunit;

namespace Kapa.Culture.Tests
{
    public class CountryTests
    {
        [Theory]
        [InlineData("GR")]
        [InlineData("gr")]
        [InlineData("   Gr   ")]
        [InlineData("   gR   ")]
        public void ShouldCreateCountryFromTwoLetterCode(string code)
        {
            var country = Country.FromCode(code);

            Assert.NotNull(country);
            Assert.True(country.ThreeLetterCode == "GRC");
            Assert.True(country.Name != default);
        }

        [Theory]
        [InlineData("GRC")]
        [InlineData("grC")]
        [InlineData("   Grc   ")]
        [InlineData("   gRC   ")]
        public void ShouldCreateCountryFromThreeLetterCode(string code)
        {
            var country = Country.FromCode(code);

            Assert.NotNull(country);
            Assert.True(country.TwoLetterCode == "GR");
            Assert.True(country.Name != default);
        }

        [Theory]
        [InlineData("300")]
        [InlineData("     300")]
        [InlineData("300    ")]
        [InlineData("   300    ")]
        public void ShouldCreateCountryFromNumericCode(string code)
        {
            var country = Country.FromCode(code);

            Assert.NotNull(country);
            Assert.True(country.ThreeLetterCode == "GRC");
            Assert.True(country.TwoLetterCode == "GR");
            Assert.True(country.Name != default);
            Assert.NotNull(country.CurrencySymbol);
            Assert.True(country.CurrencyIsoCode == "EUR");
            Assert.NotNull(country.Languages);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("    ")]
        [InlineData("")]
        public void ShouldReturnDefaultValuesForNullCode(string code)
        {
            var country = Country.FromCode(code);

            Assert.NotNull(country);
            Assert.Null(country.TwoLetterCode);
            Assert.Null(country.ThreeLetterCode);
        }

        [Theory]
        [InlineData("GR")]
        [InlineData("BE")]
        [InlineData("GB")]
        [InlineData("US")]
        public void ShouldGetThreeLetterCodeFromTwoLetterCode(string twoLetterCode)
        {
            var threeLetterCode = Countries.GetThreeLetterCodeFromTwoLetterCode(twoLetterCode);
            var country = Country.FromCode(twoLetterCode);
            
            Assert.True(threeLetterCode == country.ThreeLetterCode);
        }
        
        [Theory]
        [InlineData("GRC")]
        [InlineData("BEL")]
        [InlineData("GBR")]
        [InlineData("USA")]
        public void ShouldGetTwoLetterCodeFromTwoLetterCode(string threeLetterCode)
        {
            var twoLetterCode = Countries.GetThreeLetterCodeFromTwoLetterCode(threeLetterCode);
            var country = Country.FromCode(twoLetterCode);
            
            Assert.True(twoLetterCode == country.TwoLetterCode);
        }
        
        [Theory]
        [InlineData("GR")]
        [InlineData("BE")]
        [InlineData("GB")]
        [InlineData("US")]
        public void ShouldGetNumericCodeFromTwoLetterCode(string twoLetterCode)
        {
            var numericCode = Countries.GetNumericCodeFromTwoLetterCode(twoLetterCode);
            var country = Country.FromCode(twoLetterCode);
            
            Assert.True(numericCode == country.NumericCode);
        }
        
        [Theory]
        [InlineData("300")]
        [InlineData("056")]
        [InlineData("826")]
        [InlineData("840")]
        public void ShouldGetTwoLetterCodeFromNumericCode(string numericCode)
        {
            var twoLetterCode = Countries.GetTwoLetterCodeFromNumericCode(numericCode);
            var country = Country.FromCode(numericCode);
            
            Assert.True(twoLetterCode == country.TwoLetterCode);
        }
    }
}