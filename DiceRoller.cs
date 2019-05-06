using System;
using System.Collections.Generic;
using System.Text;

namespace ACMG_Generator
{
    class DiceRoller
    {
        private int diceRoll = 20;
        private int diceNum = 11;
        private MahouDataStore magicalGirl;
        private List<int> diceResults;

        public DiceRoller(string characterName)
        {
            diceResults = DiceRoll(diceRoll, diceNum);
            magicalGirl = new MahouDataStore(characterName, diceResults);
        }

        private List<int> DiceRoll(int diceRoll, int diceNum)
        {
            diceResults = new List<int>(diceRoll);
            //dice calculation code
            return diceResults;
        }

        public void Display()
        {
            Console.Write("Your dice were: ");

            for(int diceNum = 0; diceNum < diceResults.Count; diceNum++)
            {
                Console.Write(diceResults[diceNum]);
            }

            Console.WriteLine();
            magicalGirl.Display();
        }
    }
}
