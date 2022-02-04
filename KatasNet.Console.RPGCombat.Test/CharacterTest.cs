using Xunit;
using KatasNet.Console.RPGCombat.Enums;

namespace KatasNet.Console.RPGCombat.Test
{
    public class CharacterTest
    {

        #region IterationOne

        [Fact]
        public void CharacterShouldDealDamageToAnotherCharacter()
        {
            //Arrange
            var characterDealingDamage = new MeleeCharacter() { CharacterType = CharacterType.Melee, Position = 10 };
            var CharacterRecievingDamage = new MeleeCharacter() { CharacterType = CharacterType.Melee, Position = 12 };

            //Act
            characterDealingDamage.DealDamage(CharacterRecievingDamage, 100);


            //Assert
            Assert.Equal(900, CharacterRecievingDamage.Health);
        }

        [Fact]
        public void CharacterShouldKillAnotherCharacter()
        {
            //Arrange
            var characterKilling = new MeleeCharacter() { CharacterType = CharacterType.Melee, Position = 10 };
            var charachterDying = new MeleeCharacter() { CharacterType = CharacterType.Melee, Position = 12 };

            //Act
            characterKilling.DealDamage(charachterDying, 1000);

            //Assert
            Assert.False(charachterDying.IsAlive);

        }

        [Fact]
        public void CharacterSholdNotDealDamageToItself()
        {
            //Arrange
            var character = new MeleeCharacter() { CharacterType = CharacterType.Melee, Position = 10 };

            //Act
            character.DealDamage(character, 2000);

            //Assert
            Assert.True(character.IsAlive);
        }
        #endregion

        #region IterationTwo

        [Fact]
        public void CharacterShouldDealLessDamageToTargetFiveLevesAbove()
        {
            //Arrange
            var characterDealingDamage = new MeleeCharacter() { CharacterType = CharacterType.Melee, Position = 10 };
            var CharacterRecievingDamage = new MeleeCharacter()
            {
                CharacterType = CharacterType.Melee,
                Level = 6,
                Position = 12
            };

            //Act
            characterDealingDamage.DealDamage(CharacterRecievingDamage, 100);


            //Assert
            Assert.Equal(950, CharacterRecievingDamage.Health);
        }

        [Fact]
        public void CharacterShouldOnlyHealHimself()
        {
            //Arrange
            var characterHealing = new MeleeCharacter() { CharacterType = CharacterType.Melee, Position = 10, Health = 900 };

            //Act
            characterHealing.HealCharacter(1);

            //Assert
            Assert.True(characterHealing.Health == 901);
        }

        #endregion

        #region IterationThree

        [Fact]
        public void MeleeCharacterShouldOnlyDealDamageWhenInRange()
        {
            //Arrange
            var meleeCharacter = new MeleeCharacter()
            {
                CharacterType = CharacterType.Melee,
                Position = 2
            };

            var characterToAttack = new MeleeCharacter()
            {
                CharacterType = CharacterType.Melee,
                Position = 2
            };

            //Act
            meleeCharacter.DealDamage(characterToAttack, 1000);

            //Assert
            Assert.True(!characterToAttack.IsAlive);
        }

        [Fact]
        public void RangedCharacterShouldOnlyDealDamageWhenInRange()
        {
            //Arrange
            var rangedCharacter = new RangedCharacter()
            {
                CharacterType = CharacterType.Range,
                Position = 2
            };
            var characterToAttack = new RangedCharacter()
            {
                CharacterType = CharacterType.Melee,
                Position = 20
            };
            //Act
            rangedCharacter.DealDamage(characterToAttack, 1000);
            //Assert
            Assert.True(!characterToAttack.IsAlive);
        }

        [Fact]
        public void CharacterShouldNorDealDamageIfOutOfRange()
        {
            //Arrange
            var character = new MeleeCharacter()
            {
                CharacterType = CharacterType.Melee,
                Position = 20
            };

            var characterToDealDamage = new MeleeCharacter()
            {
                CharacterType = CharacterType.Range,
                Position = 50
            };

            //Act
            character.DealDamage(characterToDealDamage, 1000);

            //Assert
            Assert.True(characterToDealDamage.IsAlive);
        }

        #endregion


        #region IterationFour

        [Fact]
        public void CharacterShouldNotAtackAllies()
        {
            //Arrange
            var character1 = new RangedCharacter()
            {
                CharacterType = CharacterType.Range,
                Position = 10
            };

            var characterToAtack = new RangedCharacter()
            {
                CharacterType = CharacterType.Melee,
                Position = 1
            };

            var factionHorde = new Faction("Horde");

            character1.JoinToFaction(factionHorde);
            characterToAtack.JoinToFaction(factionHorde);

            //Act
            character1.DealDamage(characterToAtack, 1000);

            //Assert
            Assert.True(characterToAtack.IsAlive);
        }


        [Fact]
        public void CharacterShouldAtackEnemies()
        {
            //Arrange
            var character1 = new RangedCharacter()
            {
                CharacterType = CharacterType.Range,
                Position = 10
            };

            var characterToAtack = new MeleeCharacter()
            {
                CharacterType = CharacterType.Melee,
                Position = 1
            };

            var factionHorde = new Faction("Horde");

            character1.JoinToFaction(factionHorde);
            
            //Act
            character1.DealDamage(characterToAtack, 1000);

            //Assert
            Assert.False(characterToAtack.IsAlive);
        }



        #endregion


    }
}
