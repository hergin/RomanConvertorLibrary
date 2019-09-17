using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanConvertorLibrary{
	public class RomanConvertor{

		public static int ToArabic(String roman){

			var map = new Dictionary<char, int>();
			map.Add('M', 1000);
			map.Add('D', 500);
			map.Add('C', 100);
			map.Add('L', 50);
			map.Add('X', 10);
			map.Add('V',5);
			map.Add('I',1);
			
			for(int check =0; check<roman.Length; check++){
				int value=2;
				if(map.TryGetValue((char)roman[check], out value)){
					if(value == 0){
						throw new System.InvalidOperationException("Not a valid Roman Numeral format");
					}
				}
			}
			
			int convNum = 0;
			for(int i =0; i<roman.Length-1; i++){
				int j =i+1;
				if(map[(char)roman[i]]<map[(char)roman[j]]){
					convNum += (map[(char)roman[j]]-map[(char)roman[i]]);
					i = j; 
				}else{
					convNum += map[(char)roman[i]];
				}
			}
				return convNum;
			}
			


		public static String ToRoman(int arabic){

			if(arabic>3999||arabic<0){
				throw new System.InvalidOperationException("number was either to large or to small, aceptable range is 0-3999 inclusive")
			}

			String convString = " ";
			int ones_digit = arabic%10;
			int tens_digit = (arabic-ones_digit)%100;
			int huns_digit = (arabic-tens_digit-ones_digit)%1000;
			int thous_digit = (arabic-huns_digit-tens_digit-ones_digit)/1000;
			
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
