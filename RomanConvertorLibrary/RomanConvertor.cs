using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RomanConvertorLibrary
{
	public class RomanConvertor
	{

		public static int ToArabic(String roman)
		{
            ValidateArabicConversion(roman);
            return ConvertToArabic(roman);
        }

        private static void ValidateArabicConversion(string roman)
        {

            var validCharacters = new string[] { "I", "V", "X", "L", "C", "D", "M" };
            foreach (var c in validCharacters)
            {
                roman = roman.Replace(c, string.Empty);
            }
            if (roman == "")
            {
                return;
            }
            throw new System.FormatException();

        }
        private static Dictionary<char, int> valueMap = new Dictionary<char, int>
        {{'I',1}, {'V',5}, {'X',10}, {'L',50}, {'C',100}, {'D',500}, {'M',1000}};
            

    private static int ConvertToArabic(string roman){
   
    int arabic = 0;
    for (int k = 0; k < roman.Length; k++)
    {
        if (valueMap[roman[k]] < valueMap[roman[k + 1]] && k+1<roman.Length )
        {arabic -= valueMap[roman[k]];}
        else{arabic += valueMap[roman[k]];}
    }
    return arabic;
        }



		public static String ToRoman(int arabic)
		{
            ValidateRomanConversion(arabic);
            ConvertToRoman(arabic);
            return ConvertToRoman(arabic);

        }

         private static void ValidateRomanConversion(int arabic)
        {
           if (Enumerable.Range(1, 3999).Contains(arabic)){
                return;
            }
            throw new System.InvalidOperationException("The Arabic numeral entered cannot be validly converted into a Roman Numeral!");    
        }

        private static string ConvertToRoman(int arabic)
        {   string roman = "";
            KeyValuePair<int, string> conversionKeyValue = new KeyValuePair<int, string>(arabic,roman);
                       
        conversionKeyValue = ConvertThousand(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertNineHundred(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertFiveHundred(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertFourHundred(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertOneHundred(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertNinety(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertFifty(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertForty(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertTen(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertNine(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertFive(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertFour(conversionKeyValue.Key,conversionKeyValue.Value);
        conversionKeyValue = ConvertOne(conversionKeyValue.Key,conversionKeyValue.Value);

        return conversionKeyValue.Value;
        }

        private static KeyValuePair<int, string> ConvertThousand(int arabic, string roman)
        {
            while (arabic >= 1000)
            {
                arabic -= 1000;
                roman = roman + "M";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }
        
        private static KeyValuePair<int, string> ConvertNineHundred(int arabic, string roman)
        {
            while (arabic >= 900)
            {
                arabic -= 900;
                roman = roman + "CM";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }

        private static KeyValuePair<int, string> ConvertFiveHundred(int arabic, string roman)
        {
            while (arabic >= 500)
            {
                arabic -= 500;
                roman = roman + "D";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }

        private static KeyValuePair<int, string> ConvertFourHundred(int arabic, string roman)
        {
            while (arabic >= 400)
            {
                arabic -= 400;
                roman = roman + "CD";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }

        private static KeyValuePair<int, string> ConvertOneHundred(int arabic, string roman)
        {
            while (arabic >= 100)
            {
                arabic -= 100;
                roman = roman + "C";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }

        private static KeyValuePair<int, string> ConvertNinety(int arabic, string roman)
        {
            while (arabic >= 90)
            {
                arabic -= 90;
                roman = roman + "XC";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }

        private static KeyValuePair<int, string> ConvertFifty(int arabic, string roman)
        {
            while (arabic >= 50)
            {
                arabic -= 50;
                roman = roman + "L";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }

        private static KeyValuePair<int, string> ConvertForty(int arabic, string roman)
        {
            while (arabic >= 40)
            {
                arabic -= 40;
                roman = roman + "XL";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }

        private static KeyValuePair<int, string> ConvertTen(int arabic, string roman)
        {
            while (arabic >= 10)
            {
                arabic -= 10;
                roman = roman + "X";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }

        private static KeyValuePair<int, string> ConvertNine(int arabic, string roman)
        {
            while (arabic >= 9)
            {
                arabic -= 9;
                roman = roman + "IX";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }
        private static KeyValuePair<int, string> ConvertFive(int arabic, string roman)
        {
            while (arabic >= 5)
            {
                arabic -= 5;
                roman = roman + "V";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }

        private static KeyValuePair<int, string> ConvertFour(int arabic, string roman)
        {
            while (arabic >= 4)
            {
                arabic -= 4;
                roman = roman + "IV";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }

        private static KeyValuePair<int, string> ConvertOne(int arabic, string roman)
        {
            while (arabic >= 1)
            {
                arabic -= 1;
                roman = roman + "I";
            }
            return new KeyValuePair<int, string>(arabic, roman);
        }

    }
}
