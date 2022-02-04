using KatasNet.Console.OOP.Models;
using KatasNet.Console.OOP.Services;
using System;
using System.Diagnostics;

namespace KatasNet.Console.OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {

            System.Console.WriteLine($"A Game History brgins {DateTime.Now.TimeOfDay}");
            var gameModel = new GameModel();
            var game = new GameService(gameModel);

            while (!game.IsGameOver())
            {
                //Play
                System.Console.WriteLine("Select An Option");
                System.Console.WriteLine("1 = Add Survivor");
                System.Console.WriteLine("2 = Check Alive Survivors");

                var input = System.Console.ReadLine();

                switch (input)
                {
                    case "1":
                        System.Console.WriteLine("Add Survivor Name");
                        var survivorName = System.Console.ReadLine();
                        if (string.IsNullOrEmpty(survivorName))
                        {
                            System.Console.WriteLine("Survivor Name Cannot be empty");

                        }
                        else
                        {
                            var survivor = new Survivor() { Name = survivorName };
                            game.AddSurvivor(survivor);
                        }
                        break;
                    case "2":
                        System.Console.WriteLine($"Alive survivors: {game.GetNumberOfSurvivors()} ");
                        break;


                    default:
                        break;
                }
            }

        }
    }
}
