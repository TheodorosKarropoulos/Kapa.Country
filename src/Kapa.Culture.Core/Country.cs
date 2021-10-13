using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Kapa.Culture.Extensions;

namespace Kapa.Culture
{
    public class Country
    {
        public string TwoLetterCode { get; }
        public string ThreeLetterCode { get; }
        public string Name { get; }
        public string NumericCode { get; }
        public string CurrencyIsoCode { get; }
        public string CurrencySymbol { get; }
        public IEnumerable<string> Languages { get; }
        public IEnumerable<string> DialingCodes { get; }

        private Country()
        {

        }

        private Country(string twoLetterCode)
        {
            var regionInfo = new RegionInfo(twoLetterCode);

            TwoLetterCode = twoLetterCode;
            ThreeLetterCode = Countries.GetThreeLetterCodeFromTwoLetterCode(twoLetterCode);
            NumericCode = Countries.GetNumericCodeFromTwoLetterCode(twoLetterCode);
            Name = regionInfo.EnglishName;
            CurrencyIsoCode = regionInfo.ISOCurrencySymbol;
            CurrencySymbol = regionInfo.CurrencySymbol;
            Languages = CultureInfo.GetCultures(CultureTypes.AllCultures)
                .Where(x => x.Name.EndsWith($"-{twoLetterCode}"))
                .Select(x => x.Name);
            DialingCodes = Phones.GetDialingCodesFromTwoLetterCode(twoLetterCode);
        }

        public static Country FromCode(string code)
        {
            var country = new Country();
            
            if (string.IsNullOrEmpty(code))
            {
                return country;
            }

            var countryCode = code.Trim().ToUpper();

            if (countryCode.IsNumeric())
            {
                country = new Country(Countries.GetTwoLetterCodeFromNumericCode(countryCode));
            }
            else if (countryCode.Length == 2)
            {
                country = new Country(countryCode);
            }
            else if (countryCode.Length == 3)
            {
                country = new Country(Countries.GetTwoLetterCodeFromThreeLetterCode(countryCode));
            }

            return country;
        }
    }
}