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
            List<string> characterList = new List<string>();
            characterList.Add("I", "V", "X", "L", "C", "D", "M");
            if (characterList.Contains(roman))
            {

            }
            else
            {
                throw new FormatException();
            }
            // Replace the following line with the actual code!

        }


		public static String ToRoman(int arabic)
		{
            
            if (arabic > 3999 || arabic < 1)
            {
                throw new InvalidOperationException();

            }

        }
	}
}
