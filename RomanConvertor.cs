
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
            Dictionary<char, int> validChars = new Dictionary<char, int> { { 'I', 1 }, { 'V', 5 }, { 'X', 10 }, { 'L', 50 }, { 'C', 100 }, { 'D', 500 }, { 'M', 1000 } };

            int arabicOutput = 0;
            int current = 0;
            int previous = 0;

            for (int i = 0; i < roman.Length; i++)
            {
                if (!validChars.ContainsKey(roman[i]))
                {
                    throw new FormatException();
                }

                current = validChars[roman[i]];

                if (current > previous && previous != 0) //skip evaluation and load next value if integer "previous" is empty (0)
                {
                    arabicOutput += (current - previous);
                    current = 0;
                }
                else if (current <= previous)
                {
                    arabicOutput += previous;
                }
                previous = current;
            }
            arabicOutput += current; //add final letter value if integer "current" was <= integer "previous"
            return arabicOutput;
		}


        public static String ToRoman(int arabic)
		{
            Queue<int> subQueue = new Queue<int>(new[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1, 0});
            Dictionary<int, string> romanValues = new Dictionary<int, String> { { 1000, "M" }, { 900, "CM" }, { 500, "D" }, { 400, "CD" }, { 100, "C" }, { 90, "XC" }, { 50, "L" }, { 40, "XL" }, { 10, "X" }, { 9, "IX" }, { 5, "V" }, { 4, "IV" }, { 1, "I" } };
            String romanString = "";

            if (1 >= arabic || arabic >= 3999)
            {
                throw new InvalidOperationException();
            }

            int currentSub = subQueue.Dequeue();

            while (subQueue.Count != 0 && arabic != 0)
            {
                if(arabic >= currentSub)
                {
                    arabic -= currentSub;
                    romanString += romanValues[currentSub];
                }
                else
                {
                    currentSub = subQueue.Dequeue();
                }
            }

            return romanString;
            
		}
	}
}
