using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ACMG_Generator
{
    public enum BodyType
    {
        Unknown,
        Underdeveloped,
        Average,
        Overdeveloped
    }

    public enum Gender
    {
        Unknown,
        Male,
        Female
    }

    public enum Specialisation
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

    public enum Weapon
    {
        Unknown,
        Melee,
        Ranged,
        Mystic,
        Fist
    }

    public enum Outfit
    {
        Unknown,
        Skimpy,
        Flowing,
        Elaborate,
        Uniform
    }

    public enum Ability
    {
        Unknown,
        KillingBlow,
        Hammerspace,
        TwinnedSoul,
        FocusedAssault,
        Barrage,
        PowerofFriendship,
        Duplication,
        ThirdEye,
        Regeneration,
        Tentacles
    }

    public enum CombatPerks
    {
        Unknown,
        DualWeapon,
        MartialTraining,
        EnhancedWeapon,
        MysticArtifact,
        Gifted,
        Flexibility,
        EnhancedTransformation,
        DisguiseArtifact,
        BloodMagic,
        HammerspaceHandbag,
        EnhancedSustenance,
        EnhancedOutfit,
        HealingArtifact,
        Ally,
        MonstrousMetamorphosis,
        Sorcery,
        Wings,
        PurificationArtifact,
        Awareness,
        PowerArtifact
    }

    public enum GeneralPerks
    {
        Unknown,
        InterdimensionalTourist,
        Closure,
        Fated,
        Training,
        InterdimensionalHome,
        Incognito,
        EnvironmentalSealing,
        GetOutOfJail,
        BigDamnHero,
        AbsoluteDirection,
        BigBackpack,
        NaturalAging,
        Masculinity,
        OvercityShift,
        Money,
        Familiar,
        SoulJar,
        EternalStyle,
        AWayOut,
        FakeParents
    }

    public class AccidentalMagicalGirlDataStore
    {
        private AccidentalMagicalGirlStatCalc stats = new AccidentalMagicalGirlStatCalc();
        private DiceRoller diceResults = new DiceRoller(11, 20);
        public string name;
        public int age;
        public BodyType bodyType;
        public Gender gender;
        public Specialisation specialisation;
        public Weapon weapon;
        public Outfit outfit;
        public Ability ability;
        public List<Enum> perks = new List<Enum>();
        private string questionResponse;

        public AccidentalMagicalGirlDataStore(string characterName)
        {
            SetName(characterName);
            SetBuild(diceResults.GetDiceResults());
            SetGender(perks);
        }

        public void SetName(string characterName)
        {
            name = characterName;
        }

        public void SetAge(int diceNum)
        {
            if (diceNum > 10)
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
            if (perks.Contains(GeneralPerks.Masculinity))
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
            stats.CalculateBodyTypeStats(bodyType);
        }

        public void SetBodyType(BodyType characterBodyType)
        {
            bodyType = characterBodyType;
            stats.CalculateBodyTypeStats(bodyType);
        }

        public void SetSpecialisation(int diceNum)
        {
            specialisation = (Specialisation)diceNum;
            stats.CalculateSpecialisationStats((int)specialisation, weapon, outfit);
        }

        public void SetSpecialisation(Specialisation characterSpecialisation)
        {
            specialisation = characterSpecialisation;
            stats.CalculateSpecialisationStats((int)specialisation, weapon, outfit);
        }

        public void SetWeapon(int diceNum)
        {
            if (diceNum < 6)
            {
                weapon = Weapon.Melee;
            }
            else if (diceNum < 11)
            {
                weapon = Weapon.Ranged;
            }
            else if (diceNum < 16)
            {
                weapon = Weapon.Mystic;
            }
            else
            {
                weapon = Weapon.Fist;
            }
            stats.CalculateWeaponStats(weapon);
        }

        public void SetWeapon(Weapon characterWeapon)
        {
            weapon = characterWeapon;
            stats.CalculateWeaponStats(weapon);
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
            stats.CalculateOutfitStats(outfit);
        }

        public void SetOutfit(Outfit characterOutfit)
        {
            outfit = characterOutfit;
            stats.CalculateOutfitStats(outfit);
        }

        public void SetAbility(int diceNum)
        {
            if (diceNum > 10)
            {
                ability = (Ability)diceNum - 10;
            }
            else
            {
                ability = (Ability)diceNum;
            }
            stats.CalculateAbilityStats((int)ability);
        }

        public void SetAbility(Ability characterAbility)
        {
            ability = characterAbility;
            stats.CalculateAbilityStats((int)ability);
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
            stats.CalculateCombatPerkStats(diceNum, weapon, outfit);
        }

        public void SetCombatPerk(CombatPerks characterCombatPerk)
        {
            perks.Add(characterCombatPerk);
            stats.CalculateCombatPerkStats((int)characterCombatPerk, weapon, outfit);
        }

        public void SetGeneralPerk(int diceNum)
        {
            if (perks.Contains((GeneralPerks)diceNum))
            {
                SetCombatPerk(diceNum);
            }
            else
            {
                perks.Add((GeneralPerks)diceNum);
            }
            stats.CalculateGeneralPerkStats(diceNum);
        }

        public void SetGeneralPerk(GeneralPerks characterGeneralPerk)
        {
            perks.Add(characterGeneralPerk);
            stats.CalculateGeneralPerkStats((int)characterGeneralPerk);
        }

        public void SetDefaultStats()
        {
            stats.CalculateDefaultStats();
        }

        public List<int> GetDiceResults()
        {
            return diceResults.GetDiceResults();
        }

        public void SetBuild(List<int> diceResults)
        {
            for (int diceNum = 0; diceNum < diceResults.Count; diceNum++)
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
                        questionResponse = ResponseValidator.CheckIfValidString("Please enter desired final perk type (General/Combat)", "General", "Combat");

                        if (questionResponse == "combat")
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
            diceResults.Display();

            Console.WriteLine("BUILD DETAILS");
            Console.WriteLine("Character Name: {0}", name);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine("Gender: {0}", gender.ToString());
            Console.WriteLine("Body Type: {0}", bodyType.ToString());
            Console.WriteLine("Specialisation: {0}", specialisation.ToString());
            Console.WriteLine("Weapon: {0}", weapon.ToString());
            Console.WriteLine("Outfit: {0}", outfit.ToString());
            Console.WriteLine("Ability: {0}", ability.ToString());

            for (int perkCount = 0; perkCount < perks.Count; perkCount++)
            {
                Console.WriteLine("Perk {0}: {1}", perkCount + 1, perks[perkCount]);
            }

            stats.Display();
        }
    }
}
