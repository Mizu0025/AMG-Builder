using System;
using System.Collections.Generic;
using System.Text;

namespace ACMG_Generator
{
    class StatCalculation
    {
        protected int strength;
        protected int agility;
        protected int vitality;
        protected int magic;
        protected int luck;
        protected string questionResponse;
        protected int intQuestionResponse;

        protected void IncreaseOneStat(ref int statType, int amountIncreased)
        {
            statType = statType + amountIncreased;
        }

        protected void IncreaseOneStat(string question, string validAnswer1, string validAnswer2, ref int statType1, ref int statType2, int amountIncreased)
        {
            questionResponse = ResponseValidator.CheckIfValidString(question, validAnswer1, validAnswer2);

            if (questionResponse == validAnswer1.ToLower())
            {
                IncreaseOneStat(ref statType1, amountIncreased);
            }
            else
            {
                IncreaseOneStat(ref statType2, amountIncreased);
            }
        }

        protected void IncreaseTwoStats(string question, string validAnswer1, string validAnswer2, ref int statType1, ref int statType2, ref int statType3, int amountIncreasedStat1, int amountIncreasedStat2)
        {
            questionResponse = ResponseValidator.CheckIfValidString(question, validAnswer1, validAnswer2);

            if (questionResponse == validAnswer1.ToLower())
            {
                IncreaseOneStat(ref statType1, amountIncreasedStat1);
            }
            else
            {
                IncreaseOneStat(ref statType2, amountIncreasedStat1);
            }

            statType3 = statType3 + amountIncreasedStat2;
        }

        protected void IncreaseThreeStats(ref int statType1, ref int statType2, ref int statType3, int amountIncreased1, int amountIncreased2, int amountIncreased3)
        {
            IncreaseOneStat(ref statType1, amountIncreased1);
            IncreaseOneStat(ref statType2, amountIncreased2);
            IncreaseOneStat(ref statType3, amountIncreased3);
        }

        protected void IncreaseThreeStats(string question, string validAnswer1, string validAnswer2, ref int statType1, ref int statType2, ref int statType3, ref int statType4, int amountIncreased1, int amountIncreased2, int amountIncreased3)
        {
            questionResponse = ResponseValidator.CheckIfValidString(question, validAnswer1, validAnswer2);

            if (questionResponse == validAnswer1.ToLower())
            {
                IncreaseOneStat(ref statType3, amountIncreased3);
            }
            else
            {
                IncreaseOneStat(ref statType4, amountIncreased3);
            }

            IncreaseOneStat(ref statType1, amountIncreased1);
            IncreaseOneStat(ref statType2, amountIncreased2);
        }

        protected void IncreaseFourStats(ref int statType1, ref int statType2, ref int statType3, ref int statType4, int amountIncreased)
        {
            IncreaseOneStat(ref statType1, amountIncreased);
            IncreaseOneStat(ref statType1, amountIncreased);
            IncreaseOneStat(ref statType1, amountIncreased);
            IncreaseOneStat(ref statType1, amountIncreased);
        }
    }
}