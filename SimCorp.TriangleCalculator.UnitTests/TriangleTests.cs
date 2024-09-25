namespace SimCorp.TriangleCalculator.UnitTests
{
    internal class TriangleTests
    {
        [TestCase(3, 3, 3)]
        [TestCase(1001, 1001, 1001)]
        [TestCase(7.15, 7.15, 7.15)]
        public void Should_ReturnEquilateralType_WhenAllSidesAreTheSame_Returns(
            double sideA,
            double sideB,
            double sideC)
        {
            // Arrange
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            var triangleType = triangle.GetTriangleType();

            // Assert
            Assert.That(triangleType == TriangleType.Equilateral);
        }

        [TestCase(5, 5, 8)]
        [TestCase(0.1, 0.1, 0.19)]
        public void Should_ReturnIsoscelesType_When2SidesAreTheSame_Returns(
            double sideA,
            double sideB,
            double sideC)
        {
            // Arrange
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            var triangleType = triangle.GetTriangleType();

            // Assert
            Assert.That(triangleType == TriangleType.Isosceles);
        }

        [TestCase(3, 4, 5)]
        [TestCase(1000, 1001, 1002)]
        [TestCase(3, 4, 6.999)]
        public void Should_ReturnScaleneType_WhenEachSideIsDifferent_Returns(
            double sideA,
            double sideB,
            double sideC)
        {
            // Arrange
            var triangle = new Triangle(sideA, sideB, sideC);

            // Act
            var triangleType = triangle.GetTriangleType();

            // Assert
            Assert.That(triangleType == TriangleType.Scalene);
        }

        [TestCase(1, 2, 10)]
        [TestCase(0, 5, 7)]
        [TestCase(-3, 4, 5)]
        public void Should_Throw_WhenSidesDoNotFormTriangle_Throws(
            double sideA,
            double sideB,
            double sideC)
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Triangle(sideA, sideB, sideC));
        }
    }
}