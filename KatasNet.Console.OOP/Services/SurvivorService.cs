using KatasNet.Console.OOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasNet.Console.OOP.Services
{
    public class SurvivorService
    {

        private Survivor _survivor;
       
        public SurvivorService(Survivor survivor)
        {
            _survivor = survivor;
        }

        public void IncrementWound()
        {
            if (_survivor.Wounds >= 2)
            {
                _survivor.IsDead = true;
            }
            else
            {
                _survivor.Wounds++;
            }            
        }
        
        public void CountTurnActions()
        {
            if (_survivor.Actions == 3)
            {
                _survivor.Actions = 0;
                System.Console.WriteLine("No more actios available");
            }
            
            _survivor.Actions++;
        }

        private void ReduceEquipment(Survivor survivor)
        {
            
        }

    }
}
