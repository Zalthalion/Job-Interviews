using NUnit.Framework;
using System;
using TestTaskForEB.ResFiles;
using TestTaskForEB.RomanNumerals;

namespace TestTaskForEBTests
{
    public class RomanNumeralGeneratorTests
    {

        #region Argument Out Of Range Tests

        /// <summary>
        /// Test cases for the number being out of the allowed range of numbers [1:3999]
        /// </summary>
        [TestCase (-1)] //Below zero (below the allowed limit)
        [TestCase(0)]   //Zero (below the allowed limit)
        [TestCase(4000)]//Above the allowed limit
        public void OutOfRangeTests(int outOfRange)
        {
            //Arrange
            //For the arrange part we only need to create the class to call the Generate method
            RomanNumeralGenerator generator = new RomanNumeralGenerator();

            //Act - in this case act is not needed, but not forgotten

            //Assert
            Assert.AreEqual(RomanNumeralGeneratorRes_ENG.argOutOfRange, generator.Generate(outOfRange));    

        }

        #endregion

        #region Given Example Tests

        /// <summary>
        /// Test cases for the five given examples in the specification (also includes both max/min edge cases)
        /// </summary>
        [Test]
        public void GivenExampleCaseTests()
        {
            //Arrange
            //For the arrange part we only need to create the class to call the Generate method
            RomanNumeralGenerator generator = new RomanNumeralGenerator();

            //Act - in this case act is not needed, but not forgotten

            //Assert
            Assert.AreEqual("I", generator.Generate(1));                //Min edge case
            Assert.AreEqual("V", generator.Generate(5));    
            Assert.AreEqual("X", generator.Generate(10));
            Assert.AreEqual("XX", generator.Generate(20));
            Assert.AreEqual("MMMCMXCIX", generator.Generate(3999));     //Max edge case

        }

        #endregion

        #region Random Test Cases

        /// <summary>
        /// Test cases for random 2000 generated nnumbers
        /// </summary>
        [Test]
        public void RandomTestCases(
            [Random(1, 3999, 2000)] int d)
        {
            //Arrange
            //For the arrange part we only need to create the class to call the Generate method
            RomanNumeralGenerator generator = new RomanNumeralGenerator();
            
            //Act - in this case act is not needed, but not forgotten

            //Assert
            Assert.AreEqual(RomanNumTestHelperClass.romanNumDict[d], generator.Generate(d));

        }

        #endregion

    }
}