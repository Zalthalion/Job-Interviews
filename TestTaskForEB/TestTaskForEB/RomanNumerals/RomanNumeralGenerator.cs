using System;
using System.Collections.Generic;
using TestTaskForEB.ResFiles;

namespace TestTaskForEB.RomanNumerals
{
    /// <summary>
    /// RomanNumeralGenerator class that implements IRomanNumeralGenerator interface
    /// Contains a method that converts Arabic numbers to Roman numerals
    /// </summary>
    public class RomanNumeralGenerator : IRomanNumeralGenerator
    {

        #region Collections

        /// <summary>
        /// Dictionary that maps out the arabic numbers and their coresponding roman numerals
        /// </summary>
        protected readonly Dictionary<int, string> RomanLetters = new Dictionary<int, string>
        {
            {1000, "M" },
            {900, "CM" },
            {500, "D" },
            {400, "CD" },
            {100, "C" },
            {90, "XC" },
            {50, "L" },
            {40, "XL" },
            {10, "X" },
            {9, "IX" },
            {5, "V" },
            {4, "IV" },
            {1, "I" }
        };

        #endregion

        #region Methods

        public string Generate(int number)
        {
            try
            {
                //Checks if the given number is within range
                if(number <= 0 || number >=4000)
                {
                    throw new ArgumentOutOfRangeException();
                }

                //Result string that will contain the Roman numeral value
                string strFinalNumeral = "";
                
                //Conversion 
                while(number > 0)
                {
                    foreach(var key in RomanLetters.Keys)
                    {
                        if(number >= key)
                        {
                            number -= key;
                            strFinalNumeral += RomanLetters[key];
                            break;
                        }
                    }
                }

                return strFinalNumeral;    
            }
            catch(ArgumentOutOfRangeException)
            {
                return RomanNumeralGeneratorRes_ENG.argOutOfRange;
            }
            catch(Exception ee)
            {
                return ee.Message;
            }
        }

        #endregion

    }
}
