using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasNet.Console.RPGCombat
{
    public class Faction
    {
        public string Name { get; set; }
        public Guid FactionId { get; set; }

        public Faction(string name)
        {
            Name = name;
            FactionId = Guid.NewGuid();
        }
    }
}
