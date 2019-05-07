﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ACMG_Generator
{
    enum BodyType
    {
        Unknown,
        Underdeveloped,
        Average,
        Overdeveloped
    }

    enum Gender
    {
        Unknown,
        Male,
        Female
    }

    enum Specialisation
    {
        Unknown,
        Fire,
        Ice,
        Air,
        Spirit,
        Reinforcement,
        Psychic,
        Time,
        Lightning,
        Sound,
        Darkness,
        Illusion,
        Light,
        Wood,
        Empathic,
        Water,
        Gravity,
        Stone,
        Beast,
        Metal,
        Oddball
    }

    enum Weapon
    {
        Unknown,
        Melee,
        Ranged,
        Mystic,
        Fist
    }

    enum Outfit
    {
        Unknown,
        Skimpy,
        Flowing,
        Elaborate,
        Uniform
    }

    enum Ability
    {
        Unknown,
        Killing_Blow,
        Hammerspace,
        Twinned_Soul,
        Focused_Assault,
        Barrage,
        Power_of_Friendship,
        Duplication,
        Third_Eye,
        Regeneration,
        Tentacles
    }

    enum CombatPerks
    {
        Unknown,
        Dual_Weapon,
        Martial_Training,
        Enhanced_Weapon,
        Mystic_Artifact,
        Gifted,
        Flexibility,
        Enhanced_Transformation,
        Disguise_Artifact,
        Blood_Magic,
        Hammerspace_Handbag,
        Enhanced_Sustenance,
        Enhanced_Outfit,
        Healing_Artifact,
        Ally,
        Monstrous_Metamorphosis,
        Sorcery,
        Wings,
        Purification_Artifact,
        Awareness,
        Power_Artifact
    }

    enum GeneralPerks
    {
        Unknown,
        Interdimensional_Tourist,
        Closure,
        Fated,
        Training,
        Interdimensional_Home,
        Incognito,
        Environmental_Sealing,
        Get_Out_Of_Jail,
        Big_Damn_Hero,
        Absolute_Direction,
        Big_Backpack,
        Natural_Aging,
        Masculinity,
        Overcity_Shift,
        Money,
        Familiar,
        Soul_Jar,
        Eternal_Style,
        A_Way_Out,
        Fake_Parents
    }

    class MahouDataStore
    {
        private string name;
        private int age;
        private BodyType bodyType;
        private Gender gender;
        private Specialisation specialisation;
        private Weapon weapon;
        private Outfit outfit;
        private Ability ability;
        private List<Enum> perks = new List<Enum>();

        private int strength = 4;
        private int agility = 4;
        private int vitality = 4;
        private int magic = 4;
        private int luck = 4;
        //add stats here (STR/AGI/VIT/MAG/LCK), and some way to calc them below

        public MahouDataStore(string characterName, List<int> diceResults)
        {
            SetName(characterName);
            SetBuild(diceResults);
            SetGender(perks);
        }

        public void SetName(string characterName)
        {
            name = characterName;
        }

        public void SetAge(int diceNum)
        {
            if(diceNum > 10)
            {
                age = diceNum - 10 + 6;
            }
            else
            {
                age = diceNum + 6;
            }
        }

        public void SetGender(List<Enum> perks)
        {
            if(perks.Contains(GeneralPerks.Masculinity))
            {
                gender = Gender.Male;
            }
            else
            {
                gender = Gender.Female;
            }
        }

        public void SetGender(Gender characterGender)
        {
            gender = characterGender;
        }

        public void SetBodyType(int diceNum)
        {
            if (diceNum <= 6)
            {
                bodyType = BodyType.Underdeveloped;
            }
            else if (diceNum <= 14)
            {
                bodyType = BodyType.Average;
            }
            else
            {
                bodyType = BodyType.Overdeveloped;
            }
        }

        public void SetBodyType(BodyType characterBodyType)
        {
            bodyType = characterBodyType;
        }

        public void SetSpecialisation(int diceNum)
        {
            specialisation = (Specialisation)diceNum;
        }

        public void SetSpecialisation(Specialisation characterSpecialisation)
        {
            specialisation = characterSpecialisation;
        }

        public void SetWeapon(int diceNum)
        {
            if(diceNum < 6)
            {
                weapon = Weapon.Melee;
            }
            else if(diceNum < 11)
            {
                weapon = Weapon.Ranged;
            }
            else if(diceNum < 16)
            {
                weapon = Weapon.Mystic;
            }
            else
            {
                weapon = Weapon.Fist;
            }
        }

        public void SetWeapon(Weapon characterWeapon)
        {
            weapon = characterWeapon;
        }

        public void SetOutfit(int diceNum)
        {
            if (diceNum < 6)
            {
                outfit = Outfit.Skimpy;
            }
            else if (diceNum < 11)
            {
                outfit = Outfit.Flowing;
            }
            else if (diceNum < 16)
            {
                outfit = Outfit.Elaborate;
            }
            else
            {
                outfit = Outfit.Uniform;
            }
        }

        public void SetOutfit(Outfit characterOutfit)
        {
            outfit = characterOutfit;
        }

        public void SetAbility(int diceNum)
        {
            if(diceNum > 10)
            {
                ability = (Ability)diceNum - 10;
            }
            else
            {
                ability = (Ability)diceNum;
            }
        }

        public void SetAbility(Ability characterAbility)
        {
            ability = characterAbility;
        }

        public void SetCombatPerk(int diceNum)
        {
            if (perks.Contains((CombatPerks)diceNum)) //include catch for if perks contains same perk number in General & Combat!
            {
                SetGeneralPerk(diceNum);
            }
            else
            {
                perks.Add((CombatPerks)diceNum);
            }
        }

        public void SetCombatPerk(CombatPerks characterCombatPerk)
        {
            perks.Add(characterCombatPerk);
        }

        public void SetGeneralPerk(int diceNum)
        {
            if(perks.Contains((GeneralPerks)diceNum))
            {
                SetCombatPerk(diceNum);
            }
            else
            {
                perks.Add((GeneralPerks)diceNum);
            }
        }

        public void SetGeneralPerk(GeneralPerks characterGeneralPerk)
        {
            perks.Add(characterGeneralPerk);
        }

        public void SetBuild(List<int> diceResults)
        {
            string response;

            for(int diceNum = 0; diceNum < diceResults.Count; diceNum++)
            {
                switch (diceNum)
                {
                    case 0:
                        SetAge(diceResults[diceNum]);
                        break;

                    case 1:
                        SetBodyType(diceResults[diceNum]);
                        break;

                    case 2:
                        SetSpecialisation(diceResults[diceNum]);
                        break;

                    case 3:
                        SetWeapon(diceResults[diceNum]);
                        break;

                    case 4:
                        SetOutfit(diceResults[diceNum]);
                        break;

                    case 5:
                        SetAbility(diceResults[diceNum]);
                        break;

                    case 6:
                        SetCombatPerk(diceResults[diceNum]);
                        break;

                    case 7:
                        SetCombatPerk(diceResults[diceNum]);
                        break;

                    case 8:
                        SetGeneralPerk(diceResults[diceNum]);
                        break;

                    case 9:
                        SetGeneralPerk(diceResults[diceNum]);
                        break;

                    case 10:
                        response = ResponseValidator.CheckIfValidString("Please enter desired final perk type (General/Combat)", "General", "Combat");

                        if (response == "combat")
                        {
                            SetCombatPerk(diceResults[diceNum]);
                            break;
                        }
                        else
                        {
                            SetGeneralPerk(diceResults[diceNum]);
                            break;
                        }

                    default:
                        break;
                }
            }
        }

        public void Display()
        {
            Console.WriteLine("BUILD DETAILS");
            Console.WriteLine("Character Name: {0}", name);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine("Gender: {0}", gender.ToString());
            Console.WriteLine("Body Type: {0}", bodyType.ToString());
            Console.WriteLine("Specialisation: {0}", specialisation.ToString());
            Console.WriteLine("Weapon: {0}", weapon.ToString());
            Console.WriteLine("Outfit: {0}", outfit.ToString());
            Console.WriteLine("Ability: {0}", ability.ToString());

            for(int perkCount = 0; perkCount < perks.Count; perkCount++)
            {
                Console.WriteLine("Perk {0}: {1}", perkCount+1, perks[perkCount]);
            }

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
