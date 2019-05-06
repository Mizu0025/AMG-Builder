using System;

namespace ACMG_Generator
{
    class Stub
    {
        static void Main(string[] args)
        {
            DiceRoller diceRoll;
            string characterName;

            Console.WriteLine("What is the name of your character?");
            characterName = Console.ReadLine();
            diceRoll = new DiceRoller(characterName);
            diceRoll.Display();
            //things to do:
            //- make database (contains diceRoll, diceNum, array of character traits)
            //- Char traits (age, gender, specialisation, weapon, outfit, ability, 5 perks)
            //- Gender is female unless a perk makes them male.
            //- Age is 6 + diceroll; if above 10 subtract 10 from diceroll
            //- diceroll is 11d20
            //- display results to user at the end
        }
    }
}
