using System;
using System.Collections.Generic;
using System.Text;

namespace ACMG_Generator
{
    class MahouDataStore
    {
        private string name;
        private int age;
        private string gender;
        private string specialisation;
        private string weapon;
        private string outfit;
        private string ability;
        private List<string> perks = new List<string>();

        public MahouDataStore(string characterName, List<int> diceResults)
        {
            SetName(characterName);
            SetBuild(diceResults);
        }

        public void SetName(string characterName)
        {
            name = characterName;
        }

        public void SetAge(int characterAge)
        {
            age = characterAge;
        }

        public void SetGender(string characterGender)
        {
            name = characterGender;
        }

        public void SetSpecialisation(string characterSpecialisation)
        {
            name = characterSpecialisation;
        }

        public void SetWeapon(string characterWeapon)
        {
            name = characterWeapon;
        }

        public void SetOutfit(string characterOutfit)
        {
            name = characterOutfit;
        }

        public void SetAbility(string characterAbility)
        {
            name = characterAbility;
        }

        public void SetPerks(List<string> perksList)
        {
            //perk changing code
        }

        public void SetBuild(List<int> diceResults)
        {
            //use a for-loop to go through diceResults, assigning variables to relevant items as needed
        }

        public void Display()
        {
            Console.WriteLine("Character Name: {0}", name);
            Console.WriteLine("Age: {0}", age);
            Console.WriteLine("Gender: {0}", gender);
            Console.WriteLine("Specialisation: {0}", specialisation);
            Console.WriteLine("Weapon: {0}", weapon);
            Console.WriteLine("Outfit: {0}", outfit);
            Console.WriteLine("Ability: {0}", ability);

            for(int perkCount = 0; perkCount < perks.Length, perkCount++)
            {
                Console.WriteLine("Perk {0}: {1}", perkCount+1, perks[perkCount]);
            }
        }
    }
}
