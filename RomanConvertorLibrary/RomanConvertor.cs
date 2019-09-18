using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanConvertorLibrary
{
	public class RomanConvertor
	{

        private Dictionary<char, int> CharValues = null;    

        private string[] ThouLetters = { "", "M", "MM", "MMM" };
        private string[] HundLetters = { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
        private string[] TensLetters = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
        private string[] OnesLetters = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };


		public static int ToArabic(String roman)
		{
			// Replace the following line with the actual code!
            if (CharValues == null)
    {
            CharValues = new Dictionary<char, int>();
            CharValues.Add('I', 1);
            CharValues.Add('V', 5);
            CharValues.Add('X', 10);
            CharValues.Add('L', 50);
            CharValues.Add('C', 100);
            CharValues.Add('D', 500);
            CharValues.Add('M', 1000);
        }

            if (roman.Length == 0) return 0;
            roman = roman.ToUpper();

   
            if (roman[0] == '(')
            {
    
            int pos = roman.LastIndexOf(')');

     
            string part1 = roman.Substring(1, pos - 1);
            string part2 = roman.Substring(pos + 1);
            return 1000 * RomanToArabic(part1) + RomanToArabic(part2);
            }

    
            int total = 0;
            int last_value = 0;
            for (int i = roman.Length - 1; i >= 0; i--)
            {           
                int new_value = CharValues[roman[i]];

                if (new_value < last_value)
                total -= new_value;
                else
                {
                    total += new_value;
                    last_value = new_value;
                }
            }

        return total;

		}	
		


		public static String ToRoman(int arabic)
		{
			
			if (arabic >= 4000)
             {
       
                 int thou = arabic / 1000;
                 arabic %= 1000;
                 return "(" + ArabicToRoman(thou) + ")" +
                 ArabicToRoman(arabic);
             }

   
            string result = "";

        
            int num;
            num = arabic / 1000;
            result += ThouLetters[num];
            arabic %= 1000;

    
            num = arabic / 100;
            result += HundLetters[num];
            arabic %= 100;

    
           num = arabic / 10;
           result += TensLetters[num];
           arabic %= 10;

    
           result += OnesLetters[arabic];

           return result;
		}
	}
}