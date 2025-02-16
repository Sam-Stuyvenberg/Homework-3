//Written By Sam Stuyvenberg //02/16/2025
using System;

class Program
{
    static void Main(string[] args)
    {
        // Get an arrow and display its cost
        Arrow arrow = GetArrow();
        Console.WriteLine($"That arrow costs {arrow.Cost} gold.");
    }

    // Method to get an Arrow object based on user input
    static Arrow GetArrow()
    {
        // Gather the type of arrowhead, fletching type, and length
        Arrowhead arrowhead = GetArrowheadType();
        Fletching fletching = GetFletchingType();
        float length = GetLength();

        // Create and return a new Arrow object
        return new Arrow(arrowhead, fletching, length);
    }

    // Method to get the arrowhead type from user input
    static Arrowhead GetArrowheadType()
    {
        Console.Write("Arrowhead type (steel, wood, obsidian): ");
        string input = Console.ReadLine()?.ToLower();

        // Map user input to the corresponding Arrowhead enum using if-else
        if (input == "steel") return Arrowhead.Steel;
        else if (input == "wood") return Arrowhead.Wood;
        else if (input == "obsidian") return Arrowhead.Obsidian;
        else throw new ArgumentException("Invalid arrowhead type");
    }

    // Method to get the fletching type from user input
    static Fletching GetFletchingType()
    {
        Console.Write("Fletching type (plastic, turkey feather, goose feather): ");
        string input = Console.ReadLine()?.ToLower();

        // Map user input to the corresponding Fletching enum using if-else
        if (input == "plastic") return Fletching.Plastic;
        else if (input == "turkey feather") return Fletching.TurkeyFeathers;
        else if (input == "goose feather") return Fletching.GooseFeathers;
        else throw new ArgumentException("Invalid fletching type");
    }

    // Method to get the length of the arrow within a valid range (60-100)
    static float GetLength()
    {
        float length = 0;

        // Keep prompting until a valid length is entered
        while (length < 60 || length > 100)
        {
            Console.Write("Arrow length (between 60 and 100): ");
            length = Convert.ToSingle(Console.ReadLine());
        }

        return length;
    }
}

// Arrow class with properties for arrowhead, fletching, and length
public class Arrow
{
    public Arrowhead Arrowhead { get; }
    public Fletching Fletching { get; }
    public float Length { get; }

    // Constructor to initialize the Arrow object
    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        Arrowhead = arrowhead;
        Fletching = fletching;
        Length = length;
    }

    // Property to calculate and return the cost of the arrow
    public float Cost
    {
        get
        {
            // Calculate cost for the arrowhead using if-else
            float arrowheadCost = 0;
            if (Arrowhead == Arrowhead.Steel)
                arrowheadCost = 10;
            else if (Arrowhead == Arrowhead.Wood)
                arrowheadCost = 3;
            else if (Arrowhead == Arrowhead.Obsidian)
                arrowheadCost = 5;

            // Calculate cost for the fletching using if-else
            float fletchingCost = 0;
            if (Fletching == Fletching.Plastic)
                fletchingCost = 10;
            else if (Fletching == Fletching.TurkeyFeathers)
                fletchingCost = 5;
            else if (Fletching == Fletching.GooseFeathers)
                fletchingCost = 3;

            // Calculate cost for the shaft based on length
            float shaftCost = 0.05f * Length;

            // Total cost is the sum of all parts
            return arrowheadCost + fletchingCost + shaftCost;
        }
    }
}

// Enum for Arrowhead types
public enum Arrowhead { Steel, Wood, Obsidian }

// Enum for Fletching types
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
