//Written By Sam Stuyvenberg
using System;

class Program
{
    static void Main()        //Main. 
    {
        Arrow arrow = GetArrow();                                           //Get arrow from user.
        Console.WriteLine($"That arrow costs {arrow.GetCost()} gold.");
    }

    static Arrow GetArrow()
    {
        Arrowhead arrowhead = GetArrowheadType();      //Get Arrow Type from user.
        Fletching fletching = GetFletchingType();
        float length = GetLength();

        return new Arrow(arrowhead, fletching, length);   
    }

    static Arrowhead GetArrowheadType()
    {
        Console.Write("Arrowhead type (steel, wood, obsidian): ");  //Define whether the arrow is obsidian using if statements, steel or wood.
        string input = Console.ReadLine().ToLower();

        if (input == "steel")
            return Arrowhead.Steel;
        else if (input == "wood")
            return Arrowhead.Wood;
        else if (input == "obsidian")
            return Arrowhead.Obsidian;
        else
            throw new ArgumentException("Invalid arrowhead type");        //Invalid arrowhead return as error.
    }

    static Fletching GetFletchingType()
    {
        Console.Write("Fletching type (plastic, turkey feather, goose feather): ");   // Obtain fletching type from user by utilizijng if statements.
        string input = Console.ReadLine().ToLower();

        if (input == "plastic")
            return Fletching.Plastic;
        else if (input == "turkey feather")
            return Fletching.TurkeyFeathers;
        else if (input == "goose feather")
            return Fletching.GooseFeathers;
        else
            throw new ArgumentException("Invalid fletching type");
    }

    static float GetLength()                                //Obtain Arrow Length between 60 and 100 units
    {
        float length = 0;

        while (length < 60 || length > 100)
        {
            Console.Write("Arrow length (between 60 and 100): ");
            if (!float.TryParse(Console.ReadLine(), out length) || length < 60 || length > 100)
            {
                Console.WriteLine("Invalid input. Please enter a number between 60 and 100.");
            }
        }

        return length;
    }
}

class Arrow                                 //Arrow Classification
{
    public Arrowhead _arrowhead;
    public Fletching _fletching;
    public float _length;

    public Arrow(Arrowhead arrowhead, Fletching fletching, float length)
    {
        _arrowhead = arrowhead;
        _fletching = fletching;
        _length = length;
    }

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

enum Arrowhead { Steel, Wood, Obsidian }                            // Enum Statement for Arrowhead
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }           //Enum Statement for Fletching
