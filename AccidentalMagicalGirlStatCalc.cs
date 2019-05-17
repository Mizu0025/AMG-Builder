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

    class AccidentalMagicalGirlStatCalc : StatCalculation
    {
        new private int strength = 4;
        new private int agility = 4;
        new private int vitality = 4;
        new private int magic = 4;
        new private int luck = 4;
        private int specialisationNum;
        private int[] specialisationStat;
        private string[] specialisationStatName;
        private int[] OneStatSpecialisation = new int[2] { 3, 16 };
        private int[] TwoStatSpecialisation = new int[5] { 1, 6, 17, 19, 20 };
        private int[] ThreeStatSpecialisation = new int[11] { 2, 4, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
        private int[] FourStatSpecialisation = new int[2] { 5, 18 };
        private int increaseAnyStatAmount = 2;
        private int increaseAnyOtherStatAmount = 1;

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
            if (ability == 1)
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
            if (diceRollNum == 2 || diceRollNum == 3 || diceRollNum == 13 || diceRollNum == 19)
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
            else if (weapon == Weapon.Ranged)
            {
                IncreaseOneStat(ref agility, 1);
            }
            else if (weapon == Weapon.Mystic)
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
            for (int specCount = 0; specCount < specialisationNum; specCount++)
            {

                if (specCount <= 1)
                {
                    if (specialisationNum == OneStatSpecialisation[specCount])
                    {
                        specialisationStat[0] = specialisationStat[0] + 1;
                        break;
                    }

                    else if (specialisationNum == FourStatSpecialisation[specCount])
                    {
                        questionResponse = ResponseValidator.CheckIfValidString($"Which of the four stats increased by your specialisation do you want to increase ({specialisationStatName[0]}/{specialisationStatName[1]}/{specialisationStatName[2]}/{specialisationStatName[3]})?", specialisationStatName[0], specialisationStatName[1], specialisationStatName[2], specialisationStatName[3]);

                        if (questionResponse == specialisationStatName[0].ToLower())
                        {
                            specialisationStat[0] = specialisationStat[0] + 1;
                            break;
                        }
                        else if (questionResponse == specialisationStatName[1].ToLower())
                        {
                            specialisationStat[1] = specialisationStat[1] + 1;
                            break;
                        }
                        else
                        {
                            specialisationStat[2] = specialisationStat[2] + 1;
                            break;
                        }
                    }
                }

                if (specCount <= 3)
                {
                    if (specialisationNum == TwoStatSpecialisation[specCount])
                    {
                        questionResponse = ResponseValidator.CheckIfValidString($"Which of the two stats increased by your specialisation do you want to increase ({specialisationStatName[0]}/{specialisationStatName[1]})?", specialisationStatName[0], specialisationStatName[1]);

                        if (questionResponse == specialisationStatName[0].ToLower())
                        {
                            specialisationStat[0] = specialisationStat[0] + 1;
                            break;
                        }
                        else if (questionResponse == specialisationStatName[1].ToLower())
                        {
                            specialisationStat[1] = specialisationStat[1] + 1;
                            break;
                        }
                    }
                }

                if (specCount == 4)
                {
                    if (specialisationNum == TwoStatSpecialisation[specCount])
                    {
                        questionResponse = ResponseValidator.CheckIfValidString($"Which of the five stats you could have increased by your specialisation do you want to increase (({specialisationStatName[0]}/{specialisationStatName[1]}/{specialisationStatName[2]}/{specialisationStatName[3]}/{specialisationStatName[4]})?", specialisationStatName[0], specialisationStatName[1], specialisationStatName[2], specialisationStatName[3], specialisationStatName[4]);

                        if (questionResponse == specialisationStatName[0].ToLower())
                        {
                            specialisationStat[0] = specialisationStat[0] + 1;
                            break;
                        }
                        else if (questionResponse == specialisationStatName[1].ToLower())
                        {
                            specialisationStat[1] = specialisationStat[1] + 1;
                            break;
                        }
                        else if (questionResponse == specialisationStatName[2].ToLower())
                        {
                            specialisationStat[2] = specialisationStat[2] + 1;
                            break;
                        }
                        else if (questionResponse == specialisationStatName[3].ToLower())
                        {
                            specialisationStat[3] = specialisationStat[3] + 1;
                            break;
                        }
                        else
                        {
                            specialisationStat[4] = specialisationStat[4] + 1;
                            break;
                        }
                    }
                }

                if (specCount <= 10)
                {
                    if (specialisationNum == ThreeStatSpecialisation[specCount])
                    {
                        questionResponse = ResponseValidator.CheckIfValidString($"Which of the three stats increased by your specialisation do you want to increase (({specialisationStatName[0]}/{specialisationStatName[1]}/{specialisationStatName[2]}/)?", specialisationStatName[0], specialisationStatName[1], specialisationStatName[2]);

                        if (questionResponse == specialisationStatName[0].ToLower())
                        {
                            specialisationStat[0] = specialisationStat[0] + 1;
                            break;
                        }
                        else if (questionResponse == specialisationStatName[1].ToLower())
                        {
                            specialisationStat[1] = specialisationStat[1] + 1;
                            break;
                        }
                        else
                        {
                            specialisationStat[2] = specialisationStat[2] + 1;
                            break;
                        }
                    }
                }
            }
        }

        private void CalculateSpecialisationAndCombatPerkStats(int diceRollNum, CharacterBuildCategory characterBuildCategory, Weapon weaponType, Outfit outfitType)
        {
            if (characterBuildCategory == CharacterBuildCategory.Specialisation)
            {
                specialisationNum = diceRollNum;
            }

            switch (diceRollNum)
            {
                case 1:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseOneStat("Please enter desired ability stat bonus (STR/MAG)", "STR", "MAG", ref strength, ref magic, 3);
                        specialisationStat = new int[] { strength, magic };
                        specialisationStatName = new string[] { "STR", "MAG" };
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
                        specialisationStat = new int[] { strength, magic, vitality };
                        specialisationStatName = new string[] { "STR", "MAG", "VIT" }; break;
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
                        specialisationStat = new int[] { agility };
                        specialisationStatName = new string[] { "AGI" }; break;
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
                        specialisationStat = new int[] { magic, luck };
                        specialisationStatName = new string[] { "MAG", "LUCK" };
                        break;
                    }
                    break;

                case 5:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseFourStats(ref strength, ref agility, ref magic, ref luck, 1);
                        specialisationStat = new int[] { strength, agility, magic, luck };
                        specialisationStatName = new string[] { "STR", "AGI", "MAG", "LCK" };
                        break;
                    }
                    else
                    {
                        IncreaseSpecialisationStat(specialisationNum);
                        break;
                    }

                case 6:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseOneStat("Please enter desired ability stat bonus (MAG/LCK)", "NAG", "LCK", ref magic, ref luck, 2);
                        specialisationStat = new int[] { magic, luck };
                        specialisationStatName = new string[] { "MAG", "LCK" };
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
                        specialisationStat = new int[] { agility, vitality, luck };
                        specialisationStatName = new string[] { "AGI", "VIT", "LCK" };
                        break;
                    }
                    break;

                case 8:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseTwoStats("Please enter desired ability stat bonus (STR/MAG)", "STR", "MAG", ref strength, ref magic, ref agility, 1, 2);
                        specialisationStat = new int[] { strength, magic, agility };
                        specialisationStatName = new string[] { "STR", "MAG", "AGI" };
                        break;
                    }
                    break;

                case 9:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats(ref agility, ref magic, ref luck, 1, 2, 1);
                        specialisationStat = new int[] { agility, magic, luck };
                        specialisationStatName = new string[] { "AGI", "MAG", "LCK" };
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
                        specialisationStat = new int[] { strength, magic, vitality };
                        specialisationStatName = new string[] { "STR", "MAG", "VIT" };
                        break;
                    }
                    break;

                case 11:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats(ref strength, ref vitality, ref luck, 2, 1, 1);
                        specialisationStat = new int[] { strength, vitality, luck };
                        specialisationStatName = new string[] { "STR", "VIT", "LCK" };
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
                        specialisationStat = new int[] { agility, vitality, magic };
                        specialisationStatName = new string[] { "AGI", "VIT", "MAG" };
                        break;
                    }
                    else
                    {
                        IncreaseOutfitStat(outfitType);
                        break;
                    }

                case 13:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats(ref strength, ref vitality, ref magic, 1, 1, 2);
                        specialisationStat = new int[] { strength, vitality, magic };
                        specialisationStatName = new string[] { "STR", "VIT", "MAG" };
                        break;
                    }
                    break;

                case 14:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats(ref strength, ref magic, ref luck, 1, 1, 2);
                        specialisationStat = new int[] { strength, magic };
                        specialisationStatName = new string[] { "STR", "MAG" };
                        break;
                    }
                    else
                    {
                        IncreaseAnyStat("Please enter the number of the desired stat to increase from the following:\n1.Strength\n2.Agility\n3.Vitality\n4.Magic\n5.Luck", increaseAnyStatAmount);
                    }
                    break;

                case 15:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats(ref strength, ref agility, ref magic, 1, 2, 1);
                        specialisationStat = new int[] { strength, agility, magic };
                        specialisationStatName = new string[] { "STR", "AGI", "MAG" };
                        break;
                    }
                    break;

                case 16:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseOneStat(ref magic, 4);
                        specialisationStat = new int[] { magic };
                        specialisationStatName = new string[] { "MAG" };
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
                        specialisationStat = new int[] { strength, magic };
                        specialisationStatName = new string[] { "STR", "MAG" };
                    }
                    break;

                case 18:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseThreeStats("Please enter desired ability stat bonus (VIT/LCK)", "VIT", "LCK", ref strength, ref agility, ref vitality, ref luck, 1, 1, 1);
                        specialisationStat = new int[] { strength, agility, vitality, luck };
                        specialisationStatName = new string[] { "STR", "AGI", "VIT", "LCK" };
                    }
                    break;

                case 19:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseOneStat("Please enter the desired ability stat bonus (STR/LCK)", "STR", "LCK", ref strength, ref luck, 3);
                        specialisationStat = new int[] { strength, luck };
                        specialisationStatName = new string[] { "STR", "LCK" };
                    }
                    break;

                case 20:
                    if (characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        IncreaseAnyStat("Please enter the number of the desired stat to increase from the following:\n1.Strength\n2.Agility\n3.Vitality\n4.Magic\n5.Luck", increaseAnyStatAmount, increaseAnyOtherStatAmount);
                        specialisationStat = new int[] { strength, agility, vitality, magic, luck };
                        specialisationStatName = new string[] { "STR", "AGI", "VIT", "MAG", "LCK" };
                    }
                    break;

                default:
                    break;
            }
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

        protected void IncreaseAnyStat(string question, int amountIncreased)
        {
            intQuestionResponse = ResponseValidator.CheckIfIntValueBetween(question, 1, 5);

            switch (intQuestionResponse)
            {
                case 1:
                    IncreaseOneStat(ref strength, amountIncreased);
                    break;

                case 2:
                    IncreaseOneStat(ref agility, amountIncreased);
                    break;

                case 3:
                    IncreaseOneStat(ref vitality, amountIncreased);
                    break;

                case 4:
                    IncreaseOneStat(ref magic, amountIncreased);
                    break;

                case 5:
                    IncreaseOneStat(ref luck, amountIncreased);
                    break;

                default:
                    break;
            }
        }

        protected void IncreaseAnyStat(string question, int amountIncreased1, int amountIncreased2)
        {
            intQuestionResponse = ResponseValidator.CheckIfIntValueBetween(question, 1, 5);

            switch (intQuestionResponse)
            {
                case 1:
                    IncreaseOneStat(ref strength, amountIncreased1);
                    IncreaseAnyOtherStat("Please enter the number of the desired stat to increase from the following:\n1.Agility\n2.Vitality\n3.Magic\n4.Luck", ref agility, ref vitality, ref magic, ref luck, amountIncreased2);
                    break;

                case 2:
                    IncreaseOneStat(ref agility, amountIncreased1);
                    IncreaseAnyOtherStat("Please enter the number of the desired stat to increase from the following:\n1.Strength\n2.Vitality\n3.Magic\n4.Luck", ref strength, ref vitality, ref magic, ref luck, amountIncreased2);
                    break;

                case 3:
                    IncreaseOneStat(ref vitality, amountIncreased1);
                    IncreaseAnyOtherStat("Please enter the number of the desired stat to increase from the following:\n1.Strength\n2.Agility\n3.Magic\n4.Luck", ref strength, ref agility, ref magic, ref luck, amountIncreased2);
                    break;

                case 4:
                    IncreaseOneStat(ref magic, amountIncreased1);
                    IncreaseAnyOtherStat("Please enter the number of the desired stat to increase from the following:\n1.Strength\n2.Agility\n3.Vitality\n4.Luck", ref strength, ref agility, ref vitality, ref luck, amountIncreased2);
                    break;

                case 5:
                    IncreaseOneStat(ref luck, amountIncreased1);
                    IncreaseAnyOtherStat("Please enter the number of the desired stat to increase from the following:\n1.Strength\n2.Agility\n3.Vitality\n4.Magic", ref strength, ref agility, ref vitality, ref magic, amountIncreased2);
                    break;

                default:
                    break;
            }
        }

        protected void IncreaseAnyOtherStat(string question, ref int statType1, ref int statType2, ref int statType3, ref int statType4, int amountIncreased)
        {
            intQuestionResponse = ResponseValidator.CheckIfIntValueBetween(question, 1, 4);

            switch (intQuestionResponse)
            {
                case 1:
                    IncreaseOneStat(ref statType1, amountIncreased);
                    break;

                case 2:
                    IncreaseOneStat(ref statType2, amountIncreased);
                    break;

                case 3:
                    IncreaseOneStat(ref statType3, amountIncreased);
                    break;

                case 4:
                    IncreaseOneStat(ref statType4, amountIncreased);
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