using System;
using Xunit;

namespace Kapa.Culture.Tests
{
    public class CountryTests
    {
        [Theory()]
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

        [Theory()]
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

        [Theory()]
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

        [Theory()]
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
    }
}