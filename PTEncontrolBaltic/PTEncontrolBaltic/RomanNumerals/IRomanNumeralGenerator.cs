using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PTEncontrolBaltic.RomanNumerals
{
    /// <summary>
    /// Public interface for Roman Numeral generator
    /// </summary>
    public interface IRomanNumeralGenerator
    {
        /// <summary>
        /// Method that takes an Arabic number and converts it into a Roman numeral
        /// </summary>
        /// <param name="number">Arabic number in range [1:3999]</param>
        /// <returns>A roman numeral as a string value</returns>
        public string Generate(int number);
    }
}
