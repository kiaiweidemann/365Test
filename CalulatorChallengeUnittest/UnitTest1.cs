using CalculatorTest;

namespace CalulatorChallengeUnittest
{
    [TestClass]
    public class ChallengeCalculatorTests
    {
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            string input = "";

            // Act
            int result = Calculator.Add(input);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_SingleNumber_ReturnsNumber()
        {
            // Arrange
            string input = "20";

            // Act
            int result = Calculator.Add(input);

            // Assert
            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            string input = "1\n5";

            // Act
            int result = Calculator.Add(input);

            // Assert
            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Add_MoreThanTwoNumbers_ReturnsSum()
        {
            // Arrange
            string input = "1,2,3,4,5,6,7,8,9,10,11\n12";

            // Act
            int result = Calculator.Add(input);

            // Assert
            Assert.AreEqual(78, result);
        }

        [TestMethod]
        public void Add_NegativeNumbers_ThrowsExceptionWithNegatives()
        {
            // Arrange
            string input = "4\n-3,-12,4,-6";

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => Calculator.Add(input));
        }


        [TestMethod]
        public void Add_InvalidInput_ReturnsZero()
        {
            // Arrange
            string input = "5,tytyt";

            // Act
            int result = Calculator.Add(input);

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Add_NumbersGreaterThan1000_AreIgnored()
        {
            // Arrange
            string input = "5,1001,4";

            // Act
            int result = Calculator.Add(input);

            // Assert
            Assert.AreEqual(9, result);
        }

        [TestMethod]
        public void Add_CustomDelimiter_ReturnsSum()
        {
            // Arrange
            string input = "//#\n2#5";

            // Act
            int result = Calculator.Add(input);

            // Assert
            Assert.AreEqual(7, result);
        }

    }
}