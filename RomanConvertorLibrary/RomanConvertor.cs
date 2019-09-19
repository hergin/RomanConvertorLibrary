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
			if (roman.Contains("I, V, X, L, C, D, M") == false)
			{
				throw new FormatException();
			}
			//letter to numbers
	        Dictionary<char, int> CharValues = new Dictionary<char, int>();
			CharValues.Add('I', 1);
			CharValues.Add('V', 5);
			CharValues.Add('X', 10);
			CharValues.Add('L', 50);
			CharValues.Add('C', 100);
			CharValues.Add('D', 500);
			CharValues.Add('M', 1000);
			

			//convert letter values
			int total = 0;
			int last_value = 0;
			for (int i = roman.Length - 1; i >= 0; i--)
			{
				int new_value = CharValues[roman[i]];

				//add or subtract
				if (new_value < last_value)
					total -= new_value;
				else
				{
					total += new_value;
					last_value = new_value;
				}
			}

			//return the result
			return total;
		}

        

        public static String ToRoman(int arabic)
		{
            string[] thousands = { "", "M", "MM", "MMM" };
            string[] hundreds =
            { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
            string[] tens =
            { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
            string[] ones =
            { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };

			if(arabic < 1 || arabic > 3999)
			{
				throw new InvalidOperationException();
			}
			string result = "";

			//thousands
			int num;
			num = arabic / 1000;
			result += thousands[num];
			arabic %= 1000;

			//hundreds
			num = arabic / 100;
			result += hundreds[num];
			arabic %= 100;

			//tens
			num = arabic / 10;
			result += tens[num];
			arabic %= 10;

			//ones
			result += ones[arabic];

			return result;
		}
	}
}
