//Written By Sam Stuyvenberg //02/16/2025
using System;

namespace Simula_sTestSS
{
    internal class Program
    {
      static void Main(string[] args)
        {
            
            string currentState = "Locked";     // Start with the chest in a "Locked" state 
            
            while (true)                  // Start an infinite loop to simulate the chest interactions
            {
                
                Console.Write($"The chest is {currentState}. What do you want to do? ");                // Prompt the user for the current chest state and what they want to do
                string input = Console.ReadLine(); // Get user input

                                                                                                       
                if (currentState == "Locked" && input == "unlock")                                       // Prompt the user for the current chest state and what they want to do
                {
                    currentState = "Closed";    
                }
                else if (currentState == "Closed" && input == "open")
                {
                    currentState = "Open"; 
                }
                else if (currentState == "Open" && input == "close")
                {
                    currentState = "Closed"; 
                }
                else if (currentState == "Closed" && input == "lock")
                {
                    currentState = "Locked"; 
                }
                else
                {
                    Console.WriteLine("Invalid action! Please try again.");     // Print Error Message "Please try again."
                }
            }
        }
    }
}
