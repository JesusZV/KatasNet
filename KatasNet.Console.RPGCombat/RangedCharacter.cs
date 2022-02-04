using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasNet.Console.RPGCombat
{
    public class RangedCharacter : Character
    {
        public RangedCharacter()
        {
            CharacterType = Enums.CharacterType.Range;
        }

        public override bool IsValidRange(Character characterToDealDamage)
        {
            var distanceBetweenCharacters = characterToDealDamage.Position - Position;
            return distanceBetweenCharacters <= RANGED_RANGE;
        }

    }
}
