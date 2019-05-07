using System;
using System.Collections.Generic;
using System.Text;

namespace ACMG_Generator
{
    class DiceRoller
    {
        private int diceTotalRolls = 20;
        private int diceNumSides = 11;
        private Random randomNumGenerator = new Random();
        private MahouDataStore magicalGirl;
        private List<int> diceResults;

        public DiceRoller()
        {
            diceResults = DiceRoll(diceNumSides, diceTotalRolls);
            magicalGirl = new MahouDataStore("", diceResults);
        }

        public DiceRoller(string characterName)
        {
            diceResults = DiceRoll(diceNumSides, diceTotalRolls);
            magicalGirl = new MahouDataStore(characterName, diceResults);
        }

        private List<int> DiceRoll(int diceTotalRolls, int diceNumSides)
        {
            diceResults = new List<int>(diceTotalRolls);
            int diceGeneratedNum;

            for(int diceCount = 0; diceCount < diceTotalRolls; diceCount++)
            {
                diceGeneratedNum = randomNumGenerator.Next(1, diceNumSides);
                diceResults.Add(diceGeneratedNum);
            }

            return diceResults;
        }

        public void Display()
        {
            Console.WriteLine();
            Console.Write("DICE \n");

            for(int diceNum = 0; diceNum < diceResults.Count; diceNum++)
            {
                Console.Write(diceResults[diceNum] + " ");
            }

            Console.WriteLine("\n");
            magicalGirl.Display();
        }
    }
}
