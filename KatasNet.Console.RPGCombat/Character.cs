using KatasNet.Console.RPGCombat.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatasNet.Console.RPGCombat
{
    public abstract class Character
    {
        public int Health { get; set; } = MAX_HEALTH;
        public int Level { get; set; } = 1;
        public bool IsAlive { get; set; } = true;
        public int Position { get; set; }
        public CharacterType CharacterType { get; set; }
        public Dictionary<Guid, string> BelongingFactions { get; set; } = new Dictionary<Guid, string>();


        private const int MAX_HEALTH = 1000;
        private const decimal PERCENTAGE_TO_REDUCE = 0.5m;
        public const int MELEE_RANGE = 2;
        public const int RANGED_RANGE = 20;

        public void DealDamage(Character characterToDealDamage, int damageAmount)
        {
            if (this.Equals(characterToDealDamage) || !characterToDealDamage.IsAlive || !IsValidRange(characterToDealDamage) || IsAlly(characterToDealDamage))
            {
                return;
            }
            CalculateDamage(characterToDealDamage, damageAmount);
            KillCharacter(characterToDealDamage);
        }

        public void HealCharacter(int healAmount)
        {
            if (IsAlive && Health < MAX_HEALTH)
            {
                Health += healAmount;
            }
        }

        public void JoinToFaction(Faction faction)
        {
            if (!BelongingFactions.ContainsKey(faction.FactionId))
            {
                BelongingFactions.Add(faction.FactionId, faction.Name);
            }
        }

        public void LeaveFaction(Faction faction)
        {
            if (BelongingFactions.ContainsKey(faction.FactionId))
            {
                BelongingFactions.Remove(faction.FactionId);
            }
        }

        #region Private Methods

        public abstract bool IsValidRange(Character characterToDealDamage);
        //{
        //    var distanceBetweenCharacters = characterToDealDamage.Position - Position;
        //    switch (CharacterType)
        //    {
        //        case CharacterType.Melee:
        //            return distanceBetweenCharacters <= MELEE_RANGE;
        //        case CharacterType.Range:
        //            return distanceBetweenCharacters <= RANGED_RANGE;
        //        default:
        //            return false;
        //    }
        //}

        private void CalculateDamage(Character characterToDealDamage, int damageAmount)
        {
            if (characterToDealDamage.Level - Level >= 5)
            {
                var newDamage = damageAmount * PERCENTAGE_TO_REDUCE;
                var finalDamage = damageAmount - (int)newDamage;
                characterToDealDamage.Health -= finalDamage;
            }
            else
            {
                characterToDealDamage.Health -= damageAmount;
            }
        }

        private void KillCharacter(Character characterToDealDamage)
        {
            if (characterToDealDamage.Health <= 0)
                characterToDealDamage.IsAlive = false;
        }

        private bool IsAlly(Character characterToDealDamage)
        {
            var myFactions = BelongingFactions.Keys.ToList();
            var characterToAtackFactions = characterToDealDamage.BelongingFactions.Keys.ToList();
            var commonFactions = myFactions.Intersect(characterToAtackFactions).ToList();
            return commonFactions.Any();
        }

        #endregion
    }
}
