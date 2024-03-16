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
            string input = "1,5000";

            // Act
            int result = Calculator.Add(input);

            // Assert
            Assert.AreEqual(5001, result);
        }

        [TestMethod]
        public void Add_TwoNegativeNumbers_ReturnsSum()
        {
            // Arrange
            string input = "4,-3";

            // Act
            int result = Calculator.Add(input);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Add_MoreThanTwoNumbers_ThrowsException()
        {
            // Arrange
            string input = "1,2,3";

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
    }
}