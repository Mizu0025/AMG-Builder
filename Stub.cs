using System;

namespace ACMG_Generator
{
    class Stub
    {
        static void Main(string[] args)
        {
            DiceRoller diceRoll;
            string characterName;
            string response;
            bool repeat = true;

            while(repeat == true)
            {
                response = ResponseValidator.CheckIfValidString("Do you want to name your character (Y/N)?", "Y", "N");

                if (response == "Y")
                {
                    Console.WriteLine("What is the name of your character?");
                    characterName = Console.ReadLine();
                    diceRoll = new DiceRoller(characterName);
                }
                else
                {
                    diceRoll = new DiceRoller();
                }
                diceRoll.Display();
                Console.WriteLine();

                response = ResponseValidator.CheckIfValidString("Do you want to make another character (Y/N)?", "Y", "N");

                if (response.ToUpper() == "N")
                {
                    repeat = false;
                }
            }
        }
    }
}
