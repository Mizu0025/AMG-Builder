using System;
using System.Collections.Generic;
using System.Text;

namespace ACMG_Generator
{
    public class DiceRoller
    {
        private Random randomNumGenerator = new Random();
        private List<int> diceResults;

        public DiceRoller(int diceTotalRolls, int diceNumSides)
        {
            SetDiceRolls(diceTotalRolls, diceNumSides);
        }

        private List<int> SetDiceRolls(int diceTotalRolls, int diceNumSides)
        {
            diceResults = new List<int>(diceTotalRolls);
            int diceGeneratedNum;

            for (int diceCount = 0; diceCount < diceTotalRolls; diceCount++)
            {
                diceGeneratedNum = randomNumGenerator.Next(1, diceNumSides);
                diceResults.Add(diceGeneratedNum);
            }

            return diceResults;
        }

        public List<int> GetDiceResults()
        {
            return diceResults;
        }

        public void Display()
        {
            Console.WriteLine();
            Console.Write("DICE \n");

            for (int diceNum = 0; diceNum < diceResults.Count; diceNum++)
            {
                Console.Write(diceResults[diceNum] + " ");
            }

            Console.WriteLine("\n");
        }
    }
}
