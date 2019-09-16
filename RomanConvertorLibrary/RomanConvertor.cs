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
            // Replace the following line with the actual code!
            char[] validChars = { 'I', 'V', 'X', 'L', 'C', 'D', 'M' };
            char lastNum = 'A';
            int sum = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (!validChars.Contains(roman[i]))
                {
                    throw new FormatException();
                }
                else if(sum > 3999)
                {
                    throw new InvalidOperationException();
                }
                else if (roman[i] == 'I')
                {
                    sum += 1;
                    lastNum = 'I';
                }
                else if (roman[i] == 'V')
                {
                    if (lastNum == 'I')
                    {
                        sum += 3;
                    }
                    else
                    {
                        sum += 5;
                    }
                    lastNum = 'V';
                }
                else if (roman[i] == 'X')
                {
                    if (lastNum == 'I')
                    {
                        sum += 8;
                    }
                    else
                    {
                        sum += 10;
                    }
                    lastNum = 'X';
                }
                else if (roman[i] == 'L')
                {
                    if (lastNum == 'X')
                    {
                        sum += 30;
                    }
                    else
                    {
                        sum += 50;
                    }
                    lastNum = 'L';
                }
                else if (roman[i] == 'C')
                {
                    if (lastNum == 'X')
                    {
                        sum += 80;
                    }
                    else
                    {
                        sum += 100;
                    }
                    lastNum = 'C';
                }
                else if (roman[i] == 'D')
                {
                    if (lastNum == 'C')
                    {
                        sum += 300;
                    }
                    else
                    {
                        sum += 500;
                    }
                    lastNum = 'D';
                }

                else if (roman[i] == 'M')
                {
                    if (lastNum == 'C')
                    {
                        sum += 800;
                    }
                    else
                    {
                        sum += 1000;
                    }
                    lastNum = 'M';
                }
            }
            return sum;
        }


        public static String ToRoman(int arabic)
        {
            // Replace the following line with the actual code!
            String roman = "";
            if(arabic <= 0)
            {
                throw new InvalidOperationException();
            }
            while (arabic > 0)
            {
                if(arabic > 3999)
                {
                    throw new InvalidOperationException();
                }
                else if (arabic >= 1000)
                {
                    arabic -= 1000;
                    roman += ('M');
                }
                else if (arabic >= 900 && arabic < 1000)
                {
                    arabic -= 900;
                    roman += ('C');
                    roman += ('M');
                }
                else if (arabic >= 500 && arabic < 900)
                {
                    arabic -= 500;
                    roman += ('D');
                }
                else if (arabic >= 400 && arabic < 500)
                {
                    arabic -= 400;
                    roman += ('C');
                    roman += ('D');
                }
                else if (arabic >= 100 && arabic < 400)
                {
                    arabic -= 100;
                    roman += ('C');
                }
                else if (arabic >= 90 && arabic < 100)
                {
                    arabic -= 90;
                    roman += ('X');
                    roman += ('C');
                }
                else if (arabic >= 50 && arabic < 90)
                {
                    arabic -= 50;
                    roman += ('L');
                }

                else if (arabic >= 40 && arabic < 50)
                {
                    arabic -= 40;
                    roman += ('X');
                    roman += ('L');
                }

                else if (arabic >= 10 && arabic < 40)
                {
                    arabic -= 10;
                    roman += ('X');
                }

                else if (arabic == 9)
                {
                    arabic -= 9;
                    roman += ('I');
                    roman += ('X');
                }
                else if (arabic >= 5 && arabic < 9)
                {
                    arabic -= 5;
                    roman += ('V');
                }

                else
                {
                    arabic -= 1;
                    roman += ('I');
                }
            }
            return roman;
        }
    }
}