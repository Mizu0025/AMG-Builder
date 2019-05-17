using System;

namespace ACMG_Generator
{
    class Stub
    {
        static void Main(string[] args)
        {
            AccidentalMagicalGirlDataStore accidentalMagicalGirlDataStore;
            string characterName;
            string response;
            bool repeat = true;
            const string responseYes = "y";
            const string responseNo = "n";

            while (repeat == true)
            {
                response = ResponseValidator.CheckIfValidString("Do you want to name your character (Y/N)?", responseYes, responseNo);

                if (response == responseYes)
                {
                    Console.WriteLine("What is the name of your character?");
                    characterName = Console.ReadLine();
                    accidentalMagicalGirlDataStore = new AccidentalMagicalGirlDataStore(characterName);
                }
                else
                {
                    accidentalMagicalGirlDataStore = new AccidentalMagicalGirlDataStore("");
                }
                accidentalMagicalGirlDataStore.Display();
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
