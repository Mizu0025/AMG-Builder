﻿using System;
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
        private string questionResponse;
        private string[,] array = new string[20, 3];

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

        public void CalculateSpecialisationStats(int specialisation)
        {
            CalculateStats(specialisation, CharacterBuildCategory.Specialisation);
        }

        public void CalculateAbilityStats(int ability)
        {
            if(ability == 1)
            {
                questionResponse = ResponseValidator.CheckIfValidString("Please enter desired ability stat bonus (STR/MAG)", "STR", "MAG");

                if (questionResponse == "str")
                {
                    strength = strength + 1;
                }
                else
                {
                    magic = magic + 1;
                }
            }
        }

        public void CalculateCombatPerkStats(int diceRollNum)
        {
            CalculateStats(diceRollNum, CharacterBuildCategory.CombatPerks);
        }

        public void CalculateGeneralPerkStats(int diceRollNum)
        {
            if(diceRollNum == 2 || diceRollNum == 3 || diceRollNum == 13 || diceRollNum == 19)
            {
                luck = luck + 1;
            }
        }

        private void increaseTwoStats(string question, string validAnswer1, string validAnswer2, string statType1, string statType2, int amountIncreased)
        {
            questionResponse = ResponseValidator.CheckIfValidString(question, validAnswer1, validAnswer2);

            if (questionResponse == validAnswer1)
            {
                statType1 = statType1 + amountIncreased;
            }
            else
            {
                statType2 = statType2 + amountIncreased;
            }
        }

        private void CalculateStats(int diceRollNum, CharacterBuildCategory characterBuildCategory)
        {
            //make method for if-else checks for characterBuildCategory (takes in string question, validResponse1, validResponse2, characterBuildCategory, statType1, statType2)

            switch (diceRollNum)
            {
                case 1:
                    if(characterBuildCategory == CharacterBuildCategory.Specialisation)
                    {
                        increaseTwoStats("Please enter desired ability stat bonus (STR/MAG)", "STR", "MAG", "magic", "strength", 3);
                        //get enum StatType working so you can assign statType variable to the related stat
                        break;
                    }
                    else //Combat Perk stat assignment
                    {

                        break;
                    }

                case 2:
                    break;

                case 3:
                        break;

                case 4:
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