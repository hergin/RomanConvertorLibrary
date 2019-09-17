using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanConvertorLibrary
{
    public class RomanConvertor {
        static string[] letters = new string[] { "M",  "CM",  "D",  "CD", "C",  "XC",
                                           "L",  "XL",  "X",  "IX", "V",  "IV", "I" };
        static int[] numbers = new int[] {1000,900,500,400,100,90,50,40,10,9,5,4,1};
        public static int ToArabic(String roman)
        {
            Char[] sanityArray = new Char[] { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };

            foreach (char i in roman)
            {
                if (sanityArray.Contains(i))
                {
                    continue;
                }
                else
                {
                    throw new FormatException();
                }
            }
            return recArabic(roman);            
        }

        public static int recArabic(string roman)
        {
            if (roman == string.Empty) return 0;
            if (roman.StartsWith("M")) return 1000 + recArabic(roman.Remove(0, 1));
            if (roman.StartsWith("CM")) return 900 + recArabic(roman.Remove(0, 2));
            if (roman.StartsWith("D")) return 500 + recArabic(roman.Remove(0, 1));
            if (roman.StartsWith("CD")) return 400 + recArabic(roman.Remove(0, 2));
            if (roman.StartsWith("C")) return 100 + recArabic(roman.Remove(0, 1));
            if (roman.StartsWith("XC")) return 90 + recArabic(roman.Remove(0, 2));
            if (roman.StartsWith("L")) return 50 + recArabic(roman.Remove(0, 1));
            if (roman.StartsWith("XL")) return 40 + recArabic(roman.Remove(0, 2));
            if (roman.StartsWith("X")) return 10 + recArabic(roman.Remove(0, 1));
            if (roman.StartsWith("IX")) return 9 + recArabic(roman.Remove(0, 2));
            if (roman.StartsWith("V")) return 5 + recArabic(roman.Remove(0, 1));
            if (roman.StartsWith("IV")) return 4 + recArabic(roman.Remove(0, 2));
            if (roman.StartsWith("I")) return 1 + recArabic(roman.Remove(0, 1));
            else
            {
                throw new Exception();
            }
        }

        public static String ToRoman(int arabic)
        {
            if (arabic >= 4000 || arabic < 1)
            {
                throw new InvalidOperationException();
            }
            string roman = "";
            int a = arabic;
            for (int i = 0; i < numbers.Length; i++)
            {
                while (a >= numbers[i])
                {
                    roman += letters[i];
                    a -= numbers[i];
                }
            }
            return roman;
        }
    }
}
