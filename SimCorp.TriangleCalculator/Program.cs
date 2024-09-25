
using SimCorp.TriangleCalculator;

Console.WriteLine("Enter the lengths of the three sides of the triangle:");

try
{
    var sideA = GetPositiveDouble("Side A: ");
    var sideB = GetPositiveDouble("Side B: ");
    var sideC = GetPositiveDouble("Side C: ");

    var triangle = new Triangle(sideA, sideB, sideC);

    var triangleType = triangle.GetTriangleType();

    Console.WriteLine($"The triangle is {triangleType}.");
}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
catch (Exception ex)
{
    Console.WriteLine($"An unexpected error occurred: {ex.Message}");
}

static double GetPositiveDouble(string prompt)
{
    double result;

    do
    {
        Console.Write(prompt);

        var input = Console.ReadLine();

        if (!double.TryParse(input, out result) || result <= 0)
        {
            Console.WriteLine("Please enter a valid positive number.");
        }

    } while (result <= 0);

    return result;
}