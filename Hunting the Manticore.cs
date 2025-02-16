using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
//Written By Sam Stuyvenberg 02/12/2025
namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //[x]How far maniforce from city 
            //[x]Player 2 tk turns
            //[x]overshoot to far or good
            //[x]turn point value multiple of 3 = 3 damage
            //[x]maniticore hp = 10
            //[x]1 turn maniticore = 1dps
            //[x]consolas 15 hp
            //[x] round#
            //[x] city of maniticore = 0 game end
            //[x] Use different colors for different messages




            int manticoreHealth = 10;
            int cityHealth = 15;
            int roundNumber = 1;

            Console.Write("Player 1, how far away from the city: ");
            int distanceToCity = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Player 2, it is your turn.");

            while (cityHealth > 0 && manticoreHealth > 0)
            {
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine($"STATUS: Round: {roundNumber} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");

                int expectedDamage = ComputeExpectedDamage(roundNumber);
                Console.WriteLine($"The Cannon is expected to deal {expectedDamage} damage this round.");

                int targetRange = PromptForNumber("Enter Desired Projectile Range: ");

                DisplayAttackResult(targetRange, distanceToCity);

                if (targetRange == distanceToCity)
                    manticoreHealth -= expectedDamage;

                if (manticoreHealth > 0)
                    cityHealth--;

                roundNumber++;
            }

            if (manticoreHealth <= 0)
                ColoredWriteLine("The Manticore has been destroyed! The City of Consolas is now SAFE!", ConsoleColor.Green);
            else
                ColoredWriteLine("The City of Consolas has been destroyed.", ConsoleColor.Red);
        }

        static void ColoredWriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        static void DisplayAttackResult(int target, int actual)
        {
            if (target == actual)
                Console.WriteLine("Direct Hit!");
            else if (target < actual)
                ColoredWriteLine("The round fell short of the intended target.", ConsoleColor.Blue);
            else
                ColoredWriteLine("The round overshot the intended target.", ConsoleColor.Yellow);
        }

        
        static int ComputeExpectedDamage(int round)
        {
            bool isMultipleOfFive = round % 5 == 0;
            bool isMultipleOfThree = round % 3 == 0;
            if (isMultipleOfFive && isMultipleOfThree) return 10;
            if (isMultipleOfFive) return 3;
            if (isMultipleOfThree) return 3;
            return 1;
        }

        static int PromptForNumber(string message)
        {
            Console.Write(message);
            return Convert.ToInt32(Console.ReadLine());
        }
    }
}
