/*
 * Visitor is a behavioral design pattern that lets you separate algorithms from the objects on which they operate.
 *
 * The Visitor pattern allows you to add new operations to existing object structures without modifying those structures.
 * It is particularly useful when you have a complex object structure, such as a composite object, and you want to perform
 * operations on these objects that don't necessarily make sense in the context of the objects themselves.
 *
 * The Visitor pattern is commonly used in report generation, performing operations on complex object structures,
 * and adding new features to a library or framework without changing its code.
 *
 * TODO: Exercise: Implementing the Visitor Pattern for a simple object structure
 *
 * Objective: Implement a Visitor pattern that can perform operations on a structure of geometric shapes
 * without modifying the shape classes themselves.
 */
namespace DesignPatterns.Behavioral;

public interface IShape
{
    public void Accept(IVisitor visitor);
}

public class Rectangle(int x, int y) : IShape
{
    public int Width { get; set; } = x;

    public int Height { get; set; } = y;

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Circle(int radius) : IShape
{
    public int Radius { get; set; } = radius;

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public interface IVisitor
{
    void Visit(Rectangle rec);
    void Visit(Circle circle);
}

public class AreaCalculator() : IVisitor
{
    public double TotalArea { get; private set; }

    public void Visit(Circle circle)
    {
        double area = Math.PI * circle.Radius * circle.Radius;
        Console.WriteLine($"Circle area: {area}");
        TotalArea += area;
    }

    public void Visit(Rectangle rectangle)
    {
        double area = rectangle.Width * rectangle.Height;
        Console.WriteLine($"Rectangle area: {area}");
        TotalArea += area;
    }
}
public class VisitorExample
{
    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Observer Pattern Example:");
        Console.ResetColor();
        
        List<IShape> shapes = new List<IShape>
        {
            new Circle(5),
            new Rectangle(4, 6),
            new Circle(3)
        };

        AreaCalculator areaCalculator = new AreaCalculator();

        foreach (var shape in shapes)
        {
            shape.Accept(areaCalculator);
        }

        Console.WriteLine($"Total area: {areaCalculator.TotalArea}");
        Console.WriteLine();
    }
}