using System;
using System.Collections.Generic;
using System.Text;

namespace ACMG_Generator
{
    enum CharacterBuildCategory
    {
        Unknown,
        Specialisation,
        CombatPerks,
    }

    enum StatType
    {
        Unknown,
        Strength,
        Agility,
        Vitality,
        Magic,
        Luck
    }

    class StatCalculation
    {
        private int strength = 4;
        private int agility = 4;
        private int vitality = 4;
        private int magic = 4;
        private int luck = 4;
        private int specialisationNum;
        private string questionResponse;
        int[] specialtyOneStat = new int[1] { 3 };
        int[] specialtyTwoStat = new int[5] { 1, 6, 17, 19, 20 };
        int[] specialtyThreeStat = new int[11] { 2, 4, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        int[] specialtyFourStat = new int[2] { 5, 18 };

        public void CalculateBodyTypeStats(BodyType bodyType)
        {
            if (bodyType == BodyType.Underdeveloped)
            {
                questionResponse = ResponseValidator.CheckIfValidString("Enter desired outfit stat (MAG/LCK)", "MAG", "LCK");

                if (questionResponse == "mag")
                {
                    magic = magic + 1;
                }
                else
                {
                    luck = luck + 1;
                }
            }
            else if (bodyType == BodyType.Average)
            {
                questionResponse = ResponseValidator.CheckIfValidString("Enter desired outfit stat (AGI/VIT)", "AGI", "VIT");

                if (questionResponse == "agi")
                {
                    agility = agility + 1;
                }
                else
                {
                    vitality = vitality + 1;
                }
            }
            else
            {
                questionResponse = ResponseValidator.CheckIfValidString("Enter desired outfit stat (STR/VIT)", "STR", "VIT");

                if (questionResponse == "str")
                {
                    strength = strength + 1;
                }
                else
                {
                    vitality = vitality + 1;
                }
            }
        }

        public void CalculateWeaponStats(Weapon weapon)
        {
            if (weapon == Weapon.Melee)
            {
                strength = strength + 1;
                vitality = vitality + 1;
            }
            else if (weapon == Weapon.Ranged)
            {
                agility = agility + 1;
            }
            else if (weapon == Weapon.Mystic)
            {
                magic = magic + 1;
            }
            else
            {
                strength = strength + 2;
            }
        }

        public void CalculateOutfitStats(Outfit outfit)
        {
            if (outfit == Outfit.Skimpy)
            {
                agility = agility + 1;
            }
            else if (outfit == Outfit.Flowing)
            {
                strength = strength + 1;
            }
            else if (outfit == Outfit.Elaborate)
            {
                magic = magic + 1;
            }
            else
            {
                vitality = vitality + 1;
            }
        }

        public void CalculateSpecialisationStats(int diceRollNum, Weapon weaponType, Outfit outfitType)
        {
            CalculateSpecialisationAndCombatPerkStats(diceRollNum, CharacterBuildCategory.Specialisation, weaponType, outfitType);
        }

        public void CalculateAbilityStats(int ability)
        {
            if(ability == 1)
            {
                questionResponse = ResponseValidator.CheckIfValidString("Please enter desired ability stat bonus (STR/MAG)", "STR", "MAG");

                if (questionResponse == "str")
                {
                    IncreaseOneStat(ref strength, 1);
                }
                else
                {
                    IncreaseOneStat(ref magic, 1);
                }
            }
        }

        public void CalculateCombatPerkStats(int diceRollNum, Weapon weaponType, Outfit outfitType)
        {
            CalculateSpecialisationAndCombatPerkStats(diceRollNum, CharacterBuildCategory.CombatPerks, weaponType, outfitType);
        }

        public void CalculateGeneralPerkStats(int diceRollNum)
        {
            if(diceRollNum == 2 || diceRollNum == 3 || diceRollNum == 13 || diceRollNum == 19)
            {
                luck = luck + 1;
            }
        }

        private void DualWeaponTypeCheck(Weapon weapon)
        {
            if (weapon == Weapon.Melee)
            {
                DualWeaponStatCalc("Please choose the secondary type of your weapon (Ranged/Mystic/Fist)", "Ranged", "Mystic", "Fist", ref vitality, ref agility, ref magic, 1);
            }
            else if (weapon == Weapon.Ranged)
            {
                DualWeaponStatCalc("Please choose the secondary type of your weapon (Melee/Mystic/Fist)", "Melee", "Mystic", "Fist", ref vitality, ref agility, ref strength, 1);
            }
            else if (weapon == Weapon.Mystic)
            {
                DualWeaponStatCalc("Please choose the secondary type of your weapon (Melee/Ranged/Fist)", "Melee", "Ranged", "Fist", ref vitality, ref agility, ref magic, 1);
            }
            else
            {
                DualWeaponStatCalc("Please choose the secondary type of your weapon (Melee/Ranged/Mystic)", "Melee", "Ranged", "Mystic", ref vitality, ref agility, ref magic, 1);
            }
        }

        private void DualWeaponStatCalc(string question, string validAnswer1, string validAnswer2, string validAnswer3, ref int statType1, ref int statType2, ref int statType3, int amountIncreased)
        {
            questionResponse = ResponseValidator.CheckIfValidString(question, validAnswer1, validAnswer2, validAnswer3);

            if (questionResponse == validAnswer1.ToLower() && validAnswer1.ToLower() == "melee")
            {
                questionResponse = ResponseValidator.CheckIfValidString("Pick the stat from your secondary type melee weapon you want to increase (STR/VIT)", "STR", "VIT");

                if (questionResponse == "str")
                {
                    strength = strength + 1;
                }
                else
                {
                    vitality = vitality + 1;
                }
            }
            else
            {
                if (questionResponse == validAnswer1.ToLower())
                {
                    statType1 = statType1 + 1;
                }
                else if (questionResponse == validAnswer2.ToLower())
                {
                    statType2 = statType2 + 1;
                }
                else
                {
                    statType3 = statType3 + 1;
                }
            }
        }

        private void EnhancedWeaponStatCalc(Weapon weapon)
        {
            if (weapon == Weapon.Melee)
            {
                questionResponse = ResponseValidator.CheckIfValidString("Pick the stat from your melee weapon you want to increase (STR/VIT)", "STR", "VIT");

                if (questionResponse == "str")
                {
                    IncreaseOneStat(ref strength, 1);
                }
                else
                {
                    IncreaseOneStat(ref vitality, 1);
                }
            }
            else if(weapon == Weapon.Ranged)
            {
                IncreaseOneStat(ref agility, 1);
            }
            else if(weapon == Weapon.Mystic)
            {
                IncreaseOneStat(ref magic, 1);
            }
            else
            {
                IncreaseOneStat(ref strength, 1);
            }
        }

        private void IncreaseSpecialisationStat(int specialisationNum)
        {
            //num for 1stat - 3
            //num for 2stats - 1,6,17,19,20
            //num for 3stats - 2,4,7-15
            //num for 4stats - 5,18
            //have variable for 4 diff stats, which are assigned values in IncreaseXStat/s methods, so as to be able to use them here
            //specialisation1 = specialisationDict.GetType

            //for (int specCount = 0; specCount < 20; specCount++)
            //{
            //    if (specialisationNum == specialtyOneStat[specCount])
            //    {
            //        IncreaseOneStat(ref agility, 1);
            //    }
            //    else if (specialisationNum == specialtyTwoStat[specCount])
            //    {
            //        questionResponse = ResponseValidator.CheckIfValidString("Which of the two stats increased by your specialisation do you want to increase ({0}, {1})?", specialisationStat1, specialisationStat2);

            //        if (questionResponse == specialisationStat1)
            //        {
            //            specialisa
            //        }
            //        else
            //        {

            //        }

            //    }
            //    else if (specialisationNum == specialtyThreeStat[specCount])
            //    {
            //        //code
            //    }
            //    else if (specialisationNum == specialtyFourStat[specCount])
            //    {
            //        //code
            //    }
            //}
        }

        private void IncreaseOutfitStat(Outfit outfit)
        {
            if (outfit == Outfit.Skimpy)
            {
                IncreaseOneStat(ref agility, 1);
            }
            else if (outfit == Outfit.Flowing)
            {
                IncreaseOneStat(ref strength, 1);
            }
            else if (outfit == Outfit.Elaborate)
            {
                IncreaseOneStat(ref magic, 1);
            }
            else
            {
                IncreaseOneStat(ref vitality, 1);
            }
        }

        private void IncreaseOneStat(ref int statType, int amountIncreased)
        {
            statType = statType + amountIncreased;
        }

        private void IncreaseOneStat(string question, string validAnswer1, string validAnswer2, ref int statType1, ref int statType2, int amountIncreased)
        {
            questionResponse = ResponseValidator.CheckIfValidString(question, validAnswer1, validAnswer2);

            if (questionResponse == validAnswer1.ToLower())
            {
                IncreaseOneStat(ref statType1, amountIncreased);
            }
            else
            {
                IncreaseOneStat(ref statType2, amountIncreased);
            }
        }

        private void IncreaseTwoStats(string question, string validAnswer1, string validAnswer2, ref int statType1, ref int statType2, ref int statType3, int amountIncreasedStat1, int amountIncreasedStat2)
        {
            questionResponse = ResponseValidator.CheckIfValidString(question, validAnswer1, validAnswer2);

            if(questionResponse == validAnswer1.ToLower())
            {
                IncreaseOneStat(ref statType1, amountIncreasedStat1);
            }
            else
            {
                IncreaseOneStat(ref statType2, amountIncreasedStat1);
            }

            statType3 = statType3 + amountIncreasedStat2;
        }

        private void IncreaseThreeStats(ref int statType1, ref int statType2, ref int statType3, int amountIncreased1, int amountIncreased2, int amountIncreased3)
        {
            IncreaseOneStat(ref statType1, amountIncreased1);
            IncreaseOneStat(ref statType2, amountIncreased2);
            IncreaseOneStat(ref statType3, amountIncreased3);
        }

        private void IncreaseThreeStats(string question, string validAnswer1, string validAnswer2, ref int statType1, ref int statType2, ref int statType3, ref int statType4, int amountIncreased1, int amountIncreased2, int amountIncreased3)
        {
            questionResponse = ResponseValidator.CheckIfValidString(question, validAnswer1, validAnswer2);

            if (questionResponse == validAnswer1.ToLower())
            {
                IncreaseOneStat(ref statType3, amountIncreased3);
            }
            else
            {
                IncreaseOneStat(ref statType4, amountIncreased3);
            }

            IncreaseOneStat(ref statType1, amountIncreased1);
            IncreaseOneStat(ref statType2, amountIncreased2);
        }

        private void IncreaseFourStats(ref int statType1, ref int statType2, ref int statType3, ref int statType4, int amountIncreased)
        {
            IncreaseOneStat(ref statType1, amountIncreased);
            IncreaseOneStat(ref statType1, amountIncreased);
            IncreaseOneStat(ref statType1, amountIncreased);
            IncreaseOneStat(ref statType1, amountIncreased);
        }

        private void IncreaseAnyStat(string question, string validAnswer1, string validAnswer2, string validAnswer3, string validAnswer4, string validAnswer5, ref int statType1, ref int statType2, ref int statType3, ref int statType4, ref int statType5, int amountIncreased)
        {
            questionResponse = ResponseValidator.CheckIfValidString(question, validAnswer1, validAnswer2, validAnswer3, validAnswer4, validAnswer5);

            if (questionResponse == validAnswer1.ToLower())
            {
                IncreaseOneStat(ref statType1, amountIncreased);
            }
            else if (questionResponse == validAnswer2.ToLower())
            {
                IncreaseOneStat(ref statType2, amountIncreased);
            }
            else if (questionResponse == validAnswer3.ToLower())
            {
                IncreaseOneStat(ref statType3, amountIncreased);
            }
            else if (questionResponse == validAnswer4.ToLower())
            {
                IncreaseOneStat(ref statType4, amountIncreased);
            }
            else
            {
                IncreaseOneStat(ref statType5, amountIncreased);
            }
        }

        private void CalculateSpecialisationAndCombatPerkStats(int diceRollNum, CharacterBuildCategory characterBuildCategory, Weapon weaponType, Outfit outfitType)
        {
            if(characterBuildCategory == CharacterBuildCategory.Specialisation)
            {
                specialisationNum = diceRollNum;
            }

            switch (diceRollNum)
            {
                case 1:
                    if(characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseOneStat("Please enter desired ability stat bonus (STR/MAG)", "STR", "MAG", ref strength, ref magic, 3);
                        break;
                    }
                    else
                    {
                        DualWeaponTypeCheck(weaponType);
                        break;
                    }

                case 2:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseTwoStats("Please enter desired ability stat bonus (STR/MAG)", "STR", "MAG", ref strength, ref magic, ref vitality, 3, 1);
                        break;
                    }
                    else
                    {
                        IncreaseOneStat(ref strength, 1);
                        break;
                    }

                case 3:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseOneStat(ref agility, 4);
                        break;
                    }
                    else
                    {
                        EnhancedWeaponStatCalc(weaponType);
                        break;
                    }

                case 4:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseTwoStats("Please enter desired ability stat bonus (MAG/LCK)", "MAG", "LCK", ref magic, ref luck, ref magic, 2, 1);
                        break;
                    }
                    break;

                case 5:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseFourStats(ref strength, ref agility, ref magic, ref luck, 1);
                        break;
                    }
                    else
                    {
                        IncreaseSpecialisationStat(specialisationNum); //still need to get this working!
                        break;
                    }

                case 6:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseOneStat("Please enter desired ability stat bonus (MAG/LCK)", "NAG", "LCK", ref magic, ref luck, 2);
                        break;
                    }
                    else
                    {
                        IncreaseOneStat(ref agility, 1);
                        break;
                    }

                case 7:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseTwoStats("Please enter desired ability stat bonus (AGI/VIT)", "AGI", "VIT", ref agility, ref vitality, ref luck, 1, 2);
                        break;
                    }
                    break;

                case 8:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseTwoStats("Please enter desired ability stat bonus (STR/MAG)", "STR", "MAG", ref strength, ref magic, ref agility, 1, 2);
                        break;
                    }
                    break;

                case 9:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats(ref agility, ref magic, ref luck, 1, 2, 1);
                        break;
                    }
                    else
                    {
                        IncreaseOneStat(ref vitality, 1);
                        break;
                    }

                case 10:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseTwoStats("Please enter desired ability stat bonus (STR/MAG)", "STR", "MAG", ref strength, ref magic, ref vitality, 2, 1);
                        break;
                    }
                    break;

                case 11:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats(ref strength, ref vitality, ref luck, 2, 1, 1);
                        break;
                    }
                    else
                    {
                        IncreaseOneStat(ref vitality, 1);
                        break;
                    }

                case 12:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats(ref agility, ref vitality, ref magic, 1, 2, 1);
                        break;
                    }
                    else
                    {
                        IncreaseOutfitStat(outfitType); //increase outfit stat +1
                        break;
                    }

                case 13:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats(ref strength, ref vitality, ref magic, 1, 1, 2);
                        break;
                    }
                    break;

                case 14:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats(ref strength, ref magic, ref luck, 1, 1, 2);
                        break;
                    }
                    else
                    {
                        IncreaseAnyStat("Please enter desired ability stat bonus (STR/AGI/VIT/MAG/LCK)", "STR", "AGI", "VIT", "MAG", "LCK", ref strength, ref agility, ref vitality, ref magic, ref luck, 1);
                    }
                    break;

                case 15:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats(ref strength, ref agility, ref magic, 1, 2, 1);
                        break;
                    }
                    break;

                case 16:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseOneStat(ref magic, 4);
                        break;
                    }
                    else
                    {
                        IncreaseOneStat(ref magic, 1);
                        break;
                    }

                case 17:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseOneStat("Please enter desired ability stat bonus (STR/MAG)", "STR", "MAG", ref strength, ref magic, 3);
                    }
                    break;

                case 18:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats("Please enter desired ability stat bonus (VIT/LCK)", "VIT", "LCK", ref strength, ref agility, ref vitality, ref luck, 1, 1, 1);
                    }
                    break;

                case 19:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {

                    }
                    break;

                case 20:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {

                    }
                    break;

                default:
                    break;
            }
        }

            public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("STATS");
            Console.WriteLine("Strength: {0}", strength);
            Console.WriteLine("Agility: {0}", agility);
            Console.WriteLine("Vitality: {0}", vitality);
            Console.WriteLine("Magic: {0}", magic);
            Console.WriteLine("Luck: {0}", luck);
        }
    }
}