//Written By Sam Stuyvenberg
using System;

class Program
{
    static void Main(string[] args)
    {
        // Get an arrow and display its cost
        Arrow arrow = GetArrow();
        Console.WriteLine($"That arrow costs {arrow.GetCost()} gold.");
    }

    // Method to get an Arrow object
    static Arrow GetArrow()
    {
        Arrowhead arrowhead = GetArrowheadType();
        Fletching fletching = GetFletchingType();
        float length = GetLength();

        return new Arrow(arrowhead, fletching, length);
    }

    // Method to get the arrowhead type
    static Arrowhead GetArrowheadType()
    {
        Console.Write("Arrowhead type (steel, wood, obsidian): ");
        string input = Console.ReadLine()?.ToLower();

        if (input == "steel")
            return Arrowhead.Steel;
        else if (input == "wood")
            return Arrowhead.Wood;
        else if (input == "obsidian")
            return Arrowhead.Obsidian;
        else
            throw new ArgumentException("Invalid arrowhead type");
    }

    // Method to get the fletching type
    static Fletching GetFletchingType()
    {
        Console.Write("Fletching type (plastic, turkey feather, goose feather): ");
        string input = Console.ReadLine()?.ToLower();

        if (input == "plastic")
            return Fletching.Plastic;
        else if (input == "turkey feather")
            return Fletching.TurkeyFeathers;
        else if (input == "goose feather")
            return Fletching.GooseFeathers;
        else
            throw new ArgumentException("Invalid fletching type");
    }

    // Method to get the length of the arrow
    static float GetLength()
    {
        float length = 0;

        // Ensure the length is within the specified range
        while (length < 60 || length > 100)
        {
            Console.Write("Arrow length (between 60 and 100): ");
            length = Convert.ToSingle(Console.ReadLine());
        }

        return length;
    }
}

// Arrow class with cost calculation
public class Arrow
{
    private Arrowhead _arrowhead;
    private Fletching _fletching;
    private float _length;

    public Arrowhead GetArrowhead() => _arrowhead;
    public Fletching GetFletching() => _fletching;
    public float GetLength() => _length;

    // Constructor for creating an arrow
    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

    // Method to calculate the cost of the arrow
    public float GetCost()
    {
        float arrowheadCost = 0;
        if (_arrowhead == Arrowhead.Steel)
            arrowheadCost = 10;
        else if (_arrowhead == Arrowhead.Wood)
            arrowheadCost = 3;
        else if (_arrowhead == Arrowhead.Obsidian)
            arrowheadCost = 5;

        float fletchingCost = 0;
        if (_fletching == Fletching.Plastic)
            fletchingCost = 10;
        else if (_fletching == Fletching.TurkeyFeathers)
            fletchingCost = 5;
        else if (_fletching == Fletching.GooseFeathers)
            fletchingCost = 3;

        float shaftCost = 0.05f * _length;

        return arrowheadCost + fletchingCost + shaftCost;
    }
}

// Enum for Arrowhead types
public enum Arrowhead { Steel, Wood, Obsidian }

// Enum for Fletching types
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
