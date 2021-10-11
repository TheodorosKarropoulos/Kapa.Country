using System.Linq;

namespace Kapa.Culture.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNumeric(this string _string)
        {
            if (string.IsNullOrWhiteSpace(_string) || string.IsNullOrEmpty(_string))
            {
                return false;
            }

            return _string.All(char.IsDigit);
        }
    }
}