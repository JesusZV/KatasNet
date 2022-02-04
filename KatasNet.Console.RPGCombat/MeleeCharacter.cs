using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasNet.Console.RPGCombat
{
    public class MeleeCharacter : Character
    {

        public MeleeCharacter()
        {
            CharacterType = Enums.CharacterType.Melee;
        }

        public override bool IsValidRange(Character characterToDealDamage)
        {
            var distanceBetweenCharacters = characterToDealDamage.Position - Position;
            return distanceBetweenCharacters <= MELEE_RANGE;
        }
    }
}
