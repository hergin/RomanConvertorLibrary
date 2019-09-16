using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanConvertorLibrary
{
	public class RomanConvertor
	{

		public static int ToArabic(String roman)
		{
            // No empty strings please.
            if(roman.Length == 0) { throw new FormatException(); }
            // Numerals are just arithmatic and we do lots of comparisons.
            var directTranslation = new List<int>();
            var sum = 0;

            // Translate letters to numbers.
            foreach (var character in roman)
            {
                directTranslation.Add(NumeralLookup(character));
            }
            // Loop through each number in the list.
            for (int i = 0; i < directTranslation.Count; i++)
            {
                // If the current item is the index BEFORE the last index
                if ( i+2 < (directTranslation.Count) )
                {
                    // If the current index is greater-than or equal to the next index
                    if (directTranslation[i] >= directTranslation[i + 1])
                    {
                        // Then it is not a special case.
                        sum += directTranslation[i];
                    } else
                    {
                        // Otherwise, it's subtracted from the next number.
                        sum -= directTranslation[i];
                    }
                }
                // If the item IS the last one in the list
                else
                {
                    // Then it is not a special case.
                    sum += directTranslation[i];
                }
            }
            return sum;
		}

        private static int NumeralLookup(char numeral)
        {
            // This is so we have a nice format exception without having to parse the string for illegal characters.
            Dictionary<char,int> numeralMap = new Dictionary<char, int>()
            {
                { 'I', 1 },
                { 'V', 5 },
                {'X', 10 },
                {'L', 50 },
                {'C', 100 },
                {'D', 500 },
                {'M', 1000 }
            };
            try
            {
                return numeralMap[numeral];
            }
            catch (KeyNotFoundException)
            {
                throw new FormatException();
            }
        }

		public static String ToRoman(int arabic)
		{
            // Range limits.
            if (arabic < 1 || arabic > 3999) throw new InvalidOperationException();
            // We aren't doing calculations, so why bother leaving it an integer?
            String arabicString = arabic.ToString();
            // String padding.
            while (arabicString.Length < 4)
            {
                arabicString = "0" + arabicString;
            }
            
            return DigestArabicToRoman(arabicString);
		}

        private static String DigestArabicToRoman(String arabic)
        {
            /* Rather than do calculations and an annoying algorithm, we'll just use a lookup method with dictionaries.
             * After all it's just symbol matching, the numbers are somewhat irrelevant, and a numeric method involves repititious
             * calculations and tedium.
             */
            var onesPlace = new Dictionary<char, String>()
            {
                {'9', "IX"},
                {'8', "VIII"},
                {'7', "VII"},
                {'6', "VI"},
                {'5', "V"},
                {'4', "IV"},
                {'3', "III"},
                {'2', "II"},
                {'1', "I" },
                {'0', "" }
            };
            var tensPlace = new Dictionary<char, String>()
            {
                {'9', "XC"},
                {'8', "LXXX"},
                {'7', "LXX"},
                {'6', "LX"},
                {'5', "L"},
                {'4', "XL"},
                {'3', "XXX"},
                {'2', "XX"},
                {'1', "X" },
                {'0', "" }
            };
            var hundredsPlace = new Dictionary<char, String>()
            {
                {'9', "CM"},
                {'8', "DCCC"},
                {'7', "DCC"},
                {'6', "DC"},
                {'5', "D"},
                {'4', "CD"},
                {'3', "CCC"},
                {'2', "CC"},
                {'1', "C" },
                {'0', "" }
            };
            var thousandsPlace = new Dictionary<char, String>()
            {
                {'3', "MMM"},
                {'2', "MM"},
                {'1', "M" },
                {'0', "" }
            };

            return thousandsPlace[arabic[0]] + hundredsPlace[arabic[1]] + tensPlace[arabic[2]] + onesPlace[arabic[3]];
        }

    }
}
