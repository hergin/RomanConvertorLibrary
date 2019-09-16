using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanConvertorLibrary
{
	public class RomanConvertor
	{

        /*Requirements:
            -There are only roman numbers for the arabic numbers of 1 to 3999
            -For any number outside this range, the method will throw an InvalidOperationException
            -Numbers that fall inside the valid range will be converted to their roman equivalent*/
        public static String ToRoman(int arabic)
        {
            //This is to catch numbers outside the legal range (#>3999 and #<1)
            if (arabic > 3999 || arabic < 1) { throw new InvalidOperationException(); }

            //Initiates returned variable after exception catcher for resource saving
            string romanizedNumber = "";

            //While loop that does the actual converting of an int to roman numerals (string).
            while (arabic > 0)
            {
                if (arabic >= 1000 && arabic % 1000 >= 0)
                {
                    romanizedNumber += "M";
                    arabic -= 1000;
                }
                else if (arabic >= 900 && arabic % 900 >= 0)
                {
                    romanizedNumber += "CM";
                    arabic -= 900;
                }
                else if (arabic >= 500 && arabic % 500 >= 0)
                {
                    romanizedNumber += "D";
                    arabic -= 500;
                }
                else if (arabic >= 400 && arabic % 400 >= 0)
                {
                    romanizedNumber += "CD";
                    arabic -= 400;
                }
                else if (arabic >= 100 && arabic % 100 >= 0)
                {
                    romanizedNumber += "C";
                    arabic -= 100;
                }
                else if (arabic >= 90 && arabic % 90 >= 0)
                {
                    romanizedNumber += "XC";
                    arabic -= 90;
                }
                else if (arabic >= 50 && arabic % 50 >= 0)
                {
                    romanizedNumber += "L";
                    arabic -= 50;
                }
                else if (arabic >= 40 && arabic % 40 >= 0)
                {
                    romanizedNumber += "XL";
                    arabic -= 40;
                }
                else if (arabic >= 10 && arabic % 10 >= 0)
                {
                    romanizedNumber += "X";
                    arabic -= 10;
                }
                else if (arabic >= 9 && arabic % 9 >= 0)
                {
                    romanizedNumber += "IX";
                    arabic -= 9;
                }
                else if (arabic >= 5 && arabic % 5 >= 0)
                {
                    romanizedNumber += "V";
                    arabic -= 5;
                }
                else if (arabic >= 4 && arabic % 4 >= 0)
                {
                    romanizedNumber += "IV";
                    arabic -= 4;
                }
                else if (arabic >= 1 && arabic % 1 >= 0)
                {
                    romanizedNumber += "I";
                    arabic -= 1;
                }
            }

            return romanizedNumber;
        }



        /*Requirements:
            -Roman numbers only consist of letters: I, V, X, L, C, D, M.
            -For any string that has a different value (than those above), throw a FormatException.
            -Strings that have the valid characters will be converted to their arabic equivalent.*/
        public static int ToArabic(String roman)
		{
            //This is to catch strings with illegal characters
            string allowedChars = "IVXLCDM";
            foreach (char c in roman)
            {
                if (!allowedChars.Contains(c.ToString()))
                {
                    throw new FormatException();
                }
            }

            //Initiates returned variable after exception catcher for resource saving
            int arabicizedNumber = 0;

            //While loop that does the actual converting of an int to roman numerals (string).
            while (roman.Length > 0)
            {
                if (roman.Substring(0, 1) == "M")
                {
                    arabicizedNumber += 1000;
                    roman = roman.Remove(0, 1);
                }
                else if (roman.Length > 1 && roman.Substring(0, 2) == "CM")
                {
                    arabicizedNumber += 900;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "D")
                {
                    arabicizedNumber += 500;
                    roman = roman.Remove(0, 1);
                }
                else if (roman.Length > 1 && roman.Substring(0, 2) == "CD")
                {
                    arabicizedNumber += 400;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "C")
                {
                    arabicizedNumber += 100;
                    roman = roman.Remove(0, 1);
                }
                else if (roman.Length > 1 && roman.Substring(0, 2) == "XC")
                {
                    arabicizedNumber += 90;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "L")
                {
                    arabicizedNumber += 50;
                    roman = roman.Remove(0, 1);
                }
                else if (roman.Length > 1 && roman.Substring(0, 2) == "XL")
                {
                    arabicizedNumber += 40;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "X")
                {
                    arabicizedNumber += 10;
                    roman = roman.Remove(0, 1);
                }
                else if (roman.Length > 1 && roman.Substring(0, 2) == "IX")
                {
                    arabicizedNumber += 9;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "V")
                {
                    arabicizedNumber += 5;
                    roman = roman.Remove(0, 1);
                }
                else if (roman.Length > 1 && roman.Substring(0, 2) == "IV")
                {
                    arabicizedNumber += 4;
                    roman = roman.Remove(0, 2);
                }
                else if (roman.Substring(0, 1) == "I")
                {
                    arabicizedNumber += 1;
                    roman = roman.Remove(0, 1);
                }
            }

            return arabicizedNumber;
		}
    }
}