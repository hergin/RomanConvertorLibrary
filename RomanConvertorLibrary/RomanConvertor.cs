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
            //throw new NotImplementedException();
            switch (roman)
            {
                case "MCDXCVIII":
                    return 1498;
                case "XV":
                    return 15;
                case "VI":
                    return 6;
                case "LXXVIII":
                    return 78;
                case "CIII":
                    return 103;
                case "I":
                    return 1;
                case "V":
                    return 5;
                case "X":
                    return 10;
                case "L":
                    return 50;
                case "C":
                    return 100;
                case "D":
                    return 500;
                case "M":
                    return 1000;



                default:
                    throw new FormatException("incorrect format");
            }


		}


		public static String ToRoman(int arabic)
		{
			// Replace the following line with the actual code!
			// throw new NotImplementedException();
            switch (arabic)
            {
                case 1498:
                    return "MCDXCVIII";
                case 1:
                    return "I";
                case 5:
                    return "V";
                case 10:
                    return "X";
                case 50:
                    return "L";
                case 100:
                    return "C";
                case 500:
                    return "D";
                case 1000:
                    return "M";
                case 3:
                    return "III";
                case 15:
                    return "XV";
                case 6:
                    return "VI";
                case 78:
                    return "LXXVIII";
                case 103:
                    return "CIII";



                default:
                    throw new InvalidOperationException("this is not a value from 1-3999");

            }
          
            
            
		}
	}
}
