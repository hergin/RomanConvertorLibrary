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
            string roman_Numerals = "IVLXCMD";

            foreach (char a in roman)
            {
                if (!roman_Numerals.Contains(a))
                {

                    throw new FormatException();
                }
            }
            int b = 0;
            while (roman.Length != 0)
            {
                if (roman.Substring(0, 1) == "M")
                {
                    b += 1000;
                    roman = (roman.Remove(0, 1));
                }
                else if (roman.Length > 1 && roman.Substring(0, 2) == "CM")
                {
                    b += 900;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "D")
                {
                    b += 500;
                    roman = roman.Remove(0, 1);
                }
                else if (roman.Length > 1 && roman.Substring(0, 2) == "CD")
                {
                    b += 400;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "C")
                {
                    b += 100;
                    roman = roman.Remove(0, 1);
                }
                else if (roman.Length > 1 && roman.Substring(0, 2) == "XC")
                {
                    b += 90;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "L")
                {
                    b += 50;
                    roman = roman.Remove(0, 1);
                }
                else if (roman.Length >1 && roman.Substring(0, 2) == "XL")
                {
                    b += 40;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "X")
                {
                    b += 10;
                    roman = roman.Remove(0, 1);
                }
                else if (roman.Length > 1 && roman.Substring(0, 2) == "IX")
                {
                    b += 9;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "V")
                {
                    b += 5;
                    roman = roman.Remove(0, 1);
                }
                else if (roman.Length > 1 && roman.Substring(0, 2) == "IV")
                {
                    b += 4;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "I")
                {
                    b += 1;
                    roman = roman.Remove(0, 1);
                }

            }
            return b;
        }


        public static String ToRoman(int arabic)
        {
            if (arabic > 3999 || arabic < 1)
            {
                throw new InvalidOperationException();
            }

            string Num = "";
            while (arabic != 0)
            {

                if (arabic >= 1000)
                {
                    Num += "M";
                    arabic -= 1000;
                }
                else if (arabic >= 900)
                {
                    Num += "CM";
                    arabic -= 900;
                }
                else if (arabic >= 500)
                {
                    Num += "D";
                    arabic -= 500;
                }
                else if (arabic >= 400)
                {
                    Num += "CD";
                    arabic -= 400;
                }
                else if (arabic >= 100)
                {
                    Num += "C";
                    arabic -= 100;
                }
                else if (arabic >= 90)
                {
                    Num += "XC";
                    arabic -= 90;
                }
                else if (arabic >= 50)
                {
                    Num += "L";
                    arabic -= 50;
                }
                else if (arabic >= 40)
                {
                    Num += "XL";
                    arabic -= 40;
                }
                else if (arabic >= 10)
                {
                    Num += "X";
                    arabic -= 10;
                }
                else if (arabic >= 9)
                {
                    Num += "IX";
                    arabic -= 9;
                }
                else if (arabic >= 5)
                {
                    Num += "V";
                    arabic -= 5;
                }
                else if (arabic >= 4)
                {
                    Num += "IV";
                    arabic -= 4;
                }
                else if (arabic >= 1)
                {
                    Num += "I";
                    arabic -= 1;
                }

            }
            return Num;
        }
    }
}
