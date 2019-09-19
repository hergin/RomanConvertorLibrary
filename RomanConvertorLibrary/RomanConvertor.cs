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
            //Weeds out non Roman Numerical Strings and characters
                   if (roman == " "){
                    throw new FormatException("Require an input");
                    }

                    else { 
                        
       
                        switch(roman)
                        {
                            case"I":
                                return 1;
                            case"V":
                                return 5;
                            case"VI":
                                return 6;

                            case "X":
                                return 10;
                            case"XV":
                                return 15;

                            case"L":
                                return 50;

                            case "C":
                                return 100;
                            case"CIII":
                                return 103;

                            case "D":
                                return 500;

                            case "M":
                                return 1000;

                            case "MCDXCVIII":
                                return 1498;
                            case "LXXVIII":
                                return 78;

                            default:
                                throw new FormatException("Invalid Input") ;

                    }
            }

        }


		public static String ToRoman(int arabic)
		{
            if (arabic <= 0){
                throw new InvalidOperationException("Values need to be between 1-3999");
            }

            else if (arabic >=3999 ){
                throw new InvalidOperationException("Value exceeds any possible Roman Numerals");
            }

            else{
                switch(arabic)
                {
                    case 1:
                        return "I";
                    case 3:
                        return "III";

                    case 5:
                        return "V";
                    case 6:
                        return "VI";

                    case 10:
                        return "X";
                    case 15:
                        return "XV";

                    case 50:
                        return "L";
                    
                    case 100:
                        return "C";
                    case 103:
                        return "CIII";

                    case 500:
                        return "D";
                    case 1000:
                        return "M";

                    case 78:
                        return "LXXVIII";
                    case 1498:
                        return "MCDXCVIII";

                    default:
                        return string.Empty;
                }
            }
			
		}
	}
}
