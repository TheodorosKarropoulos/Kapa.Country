using System.Linq;
using Xunit;

namespace Kapa.Country.Tests
{
    public class CountryTests
    {
        [Theory]
        [InlineData("GR", "GRC")]
        [InlineData("gr", "GRC")]
        [InlineData("   Gr   ", "GRC")]
        [InlineData("   gR   ", "GRC")]
        [InlineData("VE", "VEN")]
        public void ShouldTrimAndCreateCountryFromTwoLetterCode(string code, string threeLetterCode)
        {
            var country = Country.FromCode(code);

            Assert.NotNull(country);
            Assert.True(country.ThreeLetterCode == threeLetterCode);
            Assert.True(country.Name != default);
        }

        [Theory]
        [InlineData("GRC", "GR")]
        [InlineData("grC", "GR")]
        [InlineData("   Grc   ", "GR")]
        [InlineData("   gRC   ", "GR")]
        [InlineData("VEN", "VE")]
        public void ShouldTrimCreateCountryFromThreeLetterCode(string code, string twoLetterCode)
        {
            var country = Country.FromCode(code);

            Assert.NotNull(country);
            Assert.True(country.TwoLetterCode == twoLetterCode);
            Assert.True(country.Name != default);
        }

        [Theory]
        [InlineData("300")]
        [InlineData("     300")]
        [InlineData("300    ")]
        [InlineData("   300    ")]
        public void ShouldTrimCreateCountryFromNumericCode(string code)
        {
            var country = Country.FromCode(code);

            Assert.NotNull(country);
            Assert.True(country.ThreeLetterCode == "GRC");
            Assert.True(country.TwoLetterCode == "GR");
            Assert.True(country.Name != default);
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
        [InlineData("VE")]
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

        [Fact]
        public void AllTwoLetterCodesShouldBeValid()
        {
            var twoLetterCodes = Countries.GetAllTwoLetterCodes();
            var countries = twoLetterCodes.Select(Country.FromCode);
            Assert.True(countries.All(x => !string.IsNullOrWhiteSpace(x.Name)));
        }
        
        [Fact]
        public void AllThreeLetterCodesShouldBeValid()
        {
            var threeLetterCodes = Countries.GetAllThreeLetterCodes();
            var countries = threeLetterCodes.Select(Country.FromCode);
            Assert.True(countries.All(x => !string.IsNullOrWhiteSpace(x.Name)));
        }
        
        [Fact]
        public void AllNumericCodesShouldBeValid()
        {
            var numericCodes = Countries.GetAllNumericCodes();
            var countries = numericCodes.Select(Country.FromCode);
            Assert.True(countries.All(x => !string.IsNullOrWhiteSpace(x.Name)));
        }
    }
}