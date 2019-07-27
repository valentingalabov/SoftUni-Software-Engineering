using SoftUniTestingFramework.Asserts;
using SoftUniTestingFramework.Attributes;
using System;

namespace MySpecialApp.Tests
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void ShouldSumSucccessfullyTwoValues()
        {
            //arrange
            int a = 10;
            int b = 20;
            int expectdResut = 30;

            //act
            Calculator calculator = new Calculator();
            var actualResult = calculator.Sum(a, b);

            //assert
            Assert.AreEqual(expectdResut, actualResult);

        }

        [TestMethod]
        public void ShouldDevideSucccessfullyTwoValues()
        {
            //arrange
            int a = 10;
            int b = 10;
            int expectdResut = 1;

            //act
            Calculator calculator = new Calculator();
            var actualResult = calculator.Devide(a, b);

            //assert
            Assert.AreEqual(expectdResut, actualResult);

        }


    }
}
