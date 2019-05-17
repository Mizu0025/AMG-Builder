using System;
using System.Collections.Generic;
using System.Text;

namespace ACMG_Generator
{
    class ResponseValidator
    {
        private static List<string> validResponses;

        public static string CheckIfAnswerEntered(string question)
        {
            string response = AskQuestionAndGetResponse(question);

            while (response == "")
            {
                response = AskQuestionAndGetResponse(question);
            }
            return response;
        }

        private static string CheckIfValidString(string question, List<string> validValues)
        {
            string response = AskQuestionAndGetResponse(question);

            while (validValues.IndexOf(response.ToLower()) == -1)
            {
                response = CheckIfAnswerEntered(question);
            }
            return response;
        }

        public static string CheckIfValidString(string question, string validResponse1, string validResponse2)
        {
            return CheckIfValidString(question, validResponses = new List<string> { validResponse1.ToLower(), validResponse2.ToLower() });
        }

        public static string CheckIfValidString(string question, string validResponse1, string validResponse2, string validResponse3)
        {
            return CheckIfValidString(question, validResponses = new List<string> { validResponse1.ToLower(), validResponse2.ToLower(), validResponse3.ToLower() });
        }

        public static string CheckIfValidString(string question, string validResponse1, string validResponse2, string validResponse3, string validResponse4)
        {
            return CheckIfValidString(question, validResponses = new List<string> { validResponse1.ToLower(), validResponse2.ToLower(), validResponse3.ToLower(), validResponse4.ToLower() });
        }

        public static string CheckIfValidString(string question, string validResponse1, string validResponse2, string validResponse3, string validResponse4, string validResponse5)
        {
            return CheckIfValidString(question, validResponses = new List<string> { validResponse1.ToLower(), validResponse2.ToLower(), validResponse3.ToLower(), validResponse4.ToLower(), validResponse5.ToLower() });
        }

        public static int CheckIfValidInt(string question)
        {
            string response = AskQuestionAndGetResponse(question);
            int intResponse;

            while (!int.TryParse(response, out intResponse))
            {
                response = CheckIfAnswerEntered(question);
            }
            return intResponse;
        }

        public static double CheckIfValidDouble(string question)
        {
            string response = AskQuestionAndGetResponse(question);
            double doubleResponse;

            while (!double.TryParse(response, out doubleResponse))
            {
                response = CheckIfAnswerEntered(question);
            }
            return doubleResponse;
        }

        public static int CheckIfIntValueBetween(string question, int lowestValue, int highestValue)
        {
            lowestValue -= 1;
            highestValue += 1;

            int intResponse = CheckIfValidInt(question);

            while (intResponse <= lowestValue || intResponse >= highestValue)
            {
                intResponse = CheckIfValidInt(question);
            }
            return intResponse;
        }

        private static string AskQuestionAndGetResponse(string question)
        {
            Console.WriteLine(question);
            return Console.ReadLine();
        }
    }
}