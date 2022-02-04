using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasNet.Console.OOP.Models
{
    public class Survivor
    {
        public string Name { get; set; }
        public int Wounds { get; set; }
        public List<Equipment> Equipment { get; set; }
        public int Actions { get; set; }

        public bool IsDead;

    }
}
