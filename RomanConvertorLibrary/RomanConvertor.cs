using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanConvertorLibrary{
	public class RomanConvertor{

		public static int ToArabic(String roman){
			
			int convNum = 0;
			
			return convNum;
		}


		public static String ToRoman(int arabic){

			String convString = " ";
			int ones_digit = arabic%10;
			int tens_digit = arabic%100-ones_digit;
			int huns_digit = arabic%1000-tens_digit;
			int thous_digit = arabic%10000-huns_digit;
			
			switch(thous_digit){
				case 0:
				break;
				case 1:
					convString += "M";
				break;
				case 2:
					convString+= "MM";
				break;
				case 3:
					convString+= "MMM";
				break;
			}
			switch(huns_digit){
				case 0:
				break;
				case 1:
					convString+= "C";
				break;
				case 2:
					convString+= "CC";
				break;
				case 3:
					convString+= "CCC";
				break;
				case 4:
					convString+= "CD";
				break;
				case 5:
					convString+= "D";
				break;
				case 6:
					convString+= "DC";
				break;
				case 7:
					convString+= "DCC";
				break;
				case 8:
					convString+= "DCCC";
				break;
				case 9:
					convString+= "CM";
				break;
			}
			switch(tens_digit){
			 case 0:
			 break;
			 case 1:
			 	convString+= "X";
			 break;
			 case 2:
			 	convString+= "XX";
			 break;
			 case 3:
			 	convString+= "XXX";
			 break;
			 case 4:
			 	convString+= "XL";
			 break;
			 case 5:
			 	convString+= "L";
			 break;
			 case 6:
			 	convString+= "LX";
			 break;
			 case 7:
			 	convString+= "LXX";
			 break;
			 case 8:
			 	convString+= "LXXX";
			 break;
			 case 9:
			 	convString+= "XC";
			 break;
			}

			switch(ones_digit){
			 case 1:
				convString+= "I";
			 break;
			 case 2:
			 	convString+= "II";
			 break;
			 case 3:
			 	convString+= "III";
			 break;
			 case 4:
			 	convString+= "IV";
			 break;
			 case 5:
			 	convString+= "V";
			 break;
			 case 6:
			 	convString+= "VI";
			 break;
			 case 7:
			 	convString+= "VII";
			 break;
			 case 8:
			 	convString+= "VI";
			 break;
			 case 9:
			 	convString+= "IX";
			 break;
			}



			return convString;
		}
	}
}
