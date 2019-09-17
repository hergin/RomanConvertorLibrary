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
            string currentRNotation = "";
            int stringPlace = 0;
            int returnValue = 0;
            int notationValue = 0;
            int secondLetter = 0;
            int consecutiveCount = 0;
            char thisChar, lastChar;

            SortedDictionary<char, int> dyRoman = new SortedDictionary<char, int>
            {
                {'M', 1000},
                {'D', 500},
                {'C', 100},
                {'L', 50},
                {'X', 10},
                {'V', 5},
                {'I', 1},
                {' ', 0}
            };
            try
            {
                roman = roman.ToUpper().TrimEnd(' ').TrimStart(' ');

                if(roman.Contains(" "))
                    throw new ArgumentOutOfRangeException("Please enter a single roman numeral.", new Exception());

                for (int x = 0; x < roman.Length; x++)
                    {
                   thisChar = roman[x];
                   lastChar = x > 0 ? roman[x - 1] : ' ';
                   consecutiveCount = (thisChar == lastChar) ? consecutiveCount = 1 : 1;
                    
                    if (dyRoman.TryGetValue(thisChar, out notationValue) && dyRoman.TryGetValue(lastChar, out secondLetter))
                    {
                    int subNumber = (notationValue.ToString()[0] == '1') ? (notationValue / 10) : (notationValue / 5);

                        if (consecutiveCount > 1 && notationValue.ToString()[0] == '5')
                        throw new ArgumentOutOfRangeException("Invalid roman numeral - invalid letter repetitions.", new Exception());

                        if (consecutiveCount > 3)
                        throw new ArgumentOutOfRangeException("Invalid roman numeral", new Exception());

                        if (subNumber > 0 && secondLetter > 0 && secondLetter != subNumber && secondLetter < notationValue)
                        throw new ArgumentOutOfRangeException("Invalid roman numeral", new Exception());
                    }
                        else
                        {
                            throw new Exception("Invalid character found.");
                        }
                    }
                while (stringPlace < roman.Length)
                {
               currentRNotation = roman.Substring(stringPlace, 1);
               stringPlace++;

                if (dyRoman.TryGetValue(currentRNotation[0] , out notationValue))
                        {
                        if ((stringPlace <= (roman.Length - 1)) && dyRoman.TryGetValue(roman[stringPlace], out secondLetter))
                            {
                                if (secondLetter > notationValue)
                                {
                                currentRNotation += roman[stringPlace];
                                stringPlace++;
                                notationValue = secondLetter - notationValue;
                                }
                            }
                        returnValue += notationValue;
                        }
                }
            }
            catch(Exception ex)
            {
                returnValue = 0;
                throw ex;    
            }
            return returnValue;
    }

		public static String ToRoman(int arabic)
		{
			string returnValue = "";
            char romanChar;
            int arabicNumber, arabicSub; 

            SortedDictionary<int, char> dyRoman= new SortedDictionary<int, char>
            {
                {1000, 'M'},
                {500, 'D'},
                {100, 'C'},
                {50, 'L'},
                {10, 'X'},
                {5, 'V'},
                {1, 'I'}
            };

            try
                {
                if (arabic > 3999 || arabic < 1)
                    {
                    throw new ArgumentOutOfRangeException("Inpur values must be between 1 and 3999.", new Exception());
                    }
                int dictionaryElement = dyRoman.Count - 1;
                arabicNumber = dyRoman.ElementAt(dictionaryElement).Key;
                romanChar = dyRoman.ElementAt(dictionaryElement).Value;
                arabicSubLevel = arabicNumber - ((arabicNumber.ToString()[0] == '1') ? (arabicNumber / 10) : (arabicNumber / 5));

                while (arabic > 0 && arabic < 4000)
                    {
                    if (arabic >= arabicNumber) 
                        {
                        if (returnValue.EndsWith(new string(romanChar, 3)) && arabicNumber.ToString()[0] == '1')
                            {
                            returnValue = returnValue.Substring(0, returnValue.Length - 3);
                            returnValue += romanChar;
                            returnValue += dyRoman.ElementAt(dictionaryElement + 1).Value;
                            }
                        else
                            {
                            returnValue += dyRoman.ElementAt(dictionaryElement).Value;
                            }
                        arabic -= arabicNumber;
                        }   
                    else if (arabic >= arabicSub)
                        {
                        if (arabicNumber.ToString()[0] == '1')
                            {
                            returnValue += dyRoman.ElementAt(dictionaryElement - 2).Value;
                            }
                        else
                            {   
                            returnValue += dyRoman.ElementAt(dictionaryElement - 1).Value;
                            }

                        returnValue += dyRoman.ElementAt(dictionaryElement).Value;

                        arabic -= arabicSub;
                        }
                    else
                        {
                        dictionaryElement--;
                        arabicNumber = dyRoman.ElementAt(dictionaryElement).Key;
                        romanChar = dyRoman.ElementAt(dictionaryElement).Value;
                        arabicSub = arabicNumber - ((arabicNumber.ToString()[0] == '1') ? (arabicNumber / 10) : (arabicNumber / 5));
                        }
                
                    }
                }
            catch
            {
                returnValue = " ";
                throw Exception;
            }

            return returnValue;
            }
        }
    }
