using KatasNet.Console.OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasNet.Console.OOP.Services
{
    public class GameService
    {
        private GameModel _gameModel;

        public GameService(GameModel gameModel)
        {
            _gameModel = gameModel;
        }

        public void AddSurvivor(Survivor survivor)
        {
            if (survivor is null)
            {
                System.Console.WriteLine("Invalid survivor");
            }

            if (_gameModel.Survivors.Any())
            {
                var survivorName = _gameModel.Survivors.Find(s => s.Name == survivor.Name).Name;
                if (!string.IsNullOrEmpty(survivorName))
                    System.Console.WriteLine("Survivor Already Exists");
            }
            else
            {                

                _gameModel.Survivors.Add(survivor);
                System.Console.WriteLine($"{survivor.Name} Added Succesfully");
            }                        
        }

        public bool IsGameOver()
        {
            var survivorsCount =  _gameModel.Survivors.Count;
            var deadSurvivorsCount = _gameModel.Survivors.FindAll(s => s.IsDead).Count;

            if (survivorsCount == 0)
            {
                return false;
            }
            else
            {
                return survivorsCount == deadSurvivorsCount;
            }            
        }

        public int GetNumberOfSurvivors()
        {
            return _gameModel.Survivors.FindAll(e => !e.IsDead).Count;
        }


    }
}
