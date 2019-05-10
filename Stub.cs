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
            const string responseYes = "y";
            const string responseNo = "n";

            //Next task - make a second character sheet which the diceRoller is used to fill out
            //make genericStatCalc class with stuff which isn't dependant on mahou char generation
            //make mahouStatCalc which inherits from generic StatCalc

            while (repeat == true)
            {
                response = ResponseValidator.CheckIfValidString("Do you want to name your character (Y/N)?", responseYes, responseNo);

                if (response == responseYes)
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

                response = ResponseValidator.CheckIfValidString("Do you want to make another character (Y/N)?", responseYes, responseNo);

                if (response == responseNo)
                {
                    repeat = false;
                }
            }
        }
    }
}
