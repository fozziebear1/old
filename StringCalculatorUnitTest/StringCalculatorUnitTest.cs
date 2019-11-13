using Microsoft.VisualStudio.TestTools.UnitTesting;

using StringCalculatorNS;
namespace StringCalculatorUnitTest
{
    [TestClass]
    public class StringCalculatorUnitTest
    {
        [TestMethod]
        public void StringCalculator_Addition_Valid_WithTwoNumber()
        {

            StringCalculator cal = new StringCalculator();
            string testString = "99,99";
            string actual = cal.Addition(testString);
            string expected = "198";
         
            Assert.AreEqual(expected, actual, false);
        }
        
        [TestMethod]
        public void StringCalculator_Addition_Valid_WithNumberAndEmpty()
        {

            StringCalculator cal = new StringCalculator();
            string testString = ",100";
            string actual = cal.Addition(testString);
            string expected = "100";

            Assert.AreEqual(expected, actual, false);
        }

        [TestMethod]
        public void StringCalculator_Addition_Valid_WithNumberAndLetters()
        {

            StringCalculator cal = new StringCalculator();
            string testString = "5,tyty";
            string actual = cal.Addition(testString);
            string expected = "5";

            Assert.AreEqual(expected, actual, false);
        }

        [TestMethod]
        public void StringCalculator_Addition_Valid_WithMoreThanTwoNumbers()
        {

            StringCalculator cal = new StringCalculator();
            string testString = "5,tyty,100";
         
           

            // Act
            try
            {
                cal.Addition(testString);
            }
            catch (System.ArgumentException e)
            {
                // Assert
                StringAssert.Contains(e.Message, StringCalculator.MaximumTwoNumberMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
