//Written By Sam Stuyvemberg //02/16/2025
using System;

class Program
{
    static void Main(string[] args)
    {
        // Get a soup tuple and display its components
        var soup = GetSoup();
        Console.WriteLine($"{soup.seasoning} {soup.ingredient} {soup.type}");

        // Alternative approach using tuple indices (Item1, Item2, Item3)
        // var soup = GetSoup();
        // Console.WriteLine($"{soup.Item3} {soup.Item2} {soup.Item1}");
    }

    // Method to get a tuple of SoupType, MainIngredient, and Seasoning
    static (SoupType type, MainIngredient ingredient, Seasoning seasoning) GetSoup()
    {
        return (GetSoupType(), GetMainIngredient(), GetSeasoning());
    }

    // Method to get the soup type
    static SoupType GetSoupType()
    {
        Console.Write("Soup type (soup, stew, gumbo): ");
        string input = Console.ReadLine()?.ToLower();

        if (input == "soup")
            return SoupType.Soup;
        else if (input == "stew")
            return SoupType.Stew;
        else if (input == "gumbo")
            return SoupType.Gumbo;
        else
            throw new ArgumentException("Invalid soup type");
    }

    // Method to get the main ingredient
    static MainIngredient GetMainIngredient()
    {
        Console.Write("Main ingredient (mushroom, chicken, carrot, potato): ");
        string input = Console.ReadLine()?.ToLower();

        if (input == "mushroom")
            return MainIngredient.Mushroom;
        else if (input == "chicken")
            return MainIngredient.Chicken;
        else if (input == "carrot")
            return MainIngredient.Carrot;
        else if (input == "potato")
            return MainIngredient.Potato;
        else
            throw new ArgumentException("Invalid main ingredient");
    }

    // Method to get the seasoning
    static Seasoning GetSeasoning()
    {
        Console.Write("Seasoning (spicy, salty, sweet): ");
        string input = Console.ReadLine()?.ToLower();

        if (input == "spicy")
            return Seasoning.Spicy;
        else if (input == "salty")
            return Seasoning.Salty;
        else if (input == "sweet")
            return Seasoning.Sweet;
        else
            throw new ArgumentException("Invalid seasoning");
    }

    // Enum for SoupType
    enum SoupType { Soup, Stew, Gumbo }

    // Enum for MainIngredient
    enum MainIngredient { Mushroom, Chicken, Carrot, Potato }

    // Enum for Seasoning
    enum Seasoning { Spicy, Salty, Sweet }
}
