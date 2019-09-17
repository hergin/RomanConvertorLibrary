using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanConvertorLibrary
{
    public class RomanConvertor
    {

        public static int ToArabic(String roman)
        {
            int convertedResult = 0;
            var romanTranslation = new Dictionary<char, int>
            {
                {'M', 1000},
                {'D', 500},
                {'C', 100},
                {'L', 50},
                {'X', 10},
                {'V', 5},
                {'I', 1}
            };
            for (int i = 0; i < roman.Length; i++)
            {
                // Check if roman is empty or contains invalid characters.
                if (roman.Length == 0 || !romanTranslation.ContainsKey(roman[i]))
                {
                    throw new FormatException();
                }
                else
                {
                    // Check if roman[i+1] is in bounds and is a valid character.
                    if (roman.Length - i >= 2 && romanTranslation.ContainsKey(roman[i + 1]))
                    {
                        // Check if the characters are special and add their proper value to the result (e.g. IX = 9, MC = 900).
                        if (romanTranslation[roman[i]] < romanTranslation[roman[i + 1]])
                        {
                            convertedResult += romanTranslation[roman[i + 1]] - romanTranslation[roman[i]];
                            i++;
                        }
                        else
                        {
                            convertedResult += romanTranslation[roman[i]];
                        }
                    }
                    else
                    {
                        convertedResult += romanTranslation[roman[i]];
                    }
                }
            }
            return convertedResult;
        }

        public static String ToRoman(int arabic)
        {
            string convertedResult = "";
            // OrderedDictionary allows us to go through the dictionary sequentially; necessary for this method.
            var arabicTranslation = new OrderedDictionary
            {
                {1000, "M"},
                {900, "CM"},
                {500, "D"},
                {400, "CD"},
                {100, "C"},
                {90, "XC"},
                {50, "L"},
                {40, "XL"},
                {10, "X"},
                {9, "IX"},
                {5, "V"},
                {4, "IV"},
                {1, "I"}
            };
            if (0 >= arabic || arabic > 3999)
            {
                throw new InvalidOperationException();
            }
            int arabicIndex = 0;
            // We subtract from arabic, adding Roman numerals as we do, until arabic is equal to 0.
            while (arabic > 0)
            {
                // arabicKeyValue is how we get the key itself (the value of a particular numeral); we can't grab the key in an OrderedDictionary through any built-in method.
                int arabicKeyValue = Int32.Parse(arabicTranslation.Cast<DictionaryEntry>().ElementAt(arabicIndex).Key.ToString());
                // We see if our current Roman numeral fits into our number.
                if (arabic - arabicKeyValue >= 0)
                {
                    arabic -= arabicKeyValue;
                    convertedResult += arabicTranslation[arabicIndex];
                }
                else
                {
                    // We go down arabicTranslation, to the next lowest key.
                    arabicIndex += 1;
                }
            }
            return convertedResult;
        }
    }
}