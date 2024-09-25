namespace SimCorp.TriangleCalculator
{
    public class Triangle
    {
        public double SideA { get; private set; }

        public double SideB { get; private set; }

        public double SideC { get; private set; }

        public Triangle(
            double sideA,
            double sideB,
            double sideC)
        {
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;

            if (!IsValidTriangle())
            {
                throw new ArgumentException("The provided sides do not form a valid triangle.");
            }
        }

        private bool IsValidTriangle()
            => SideA > 0 && SideB > 0 && SideC > 0 &&
                   (SideA + SideB > SideC) &&
                   (SideA + SideC > SideB) &&
                   (SideB + SideC > SideA);

        public TriangleType GetTriangleType()
        {
            if (SideA == SideB && SideB == SideC)
            {
                return TriangleType.Equilateral;
            }
            else if (SideA == SideB || SideA == SideC || SideB == SideC)
            {
                return TriangleType.Isosceles;
            }
            else
            {
                return TriangleType.Scalene;
            }
        }
    }
}
