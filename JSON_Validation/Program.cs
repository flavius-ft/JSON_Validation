using System;

namespace JSON_Validation
{
    public class Program
    {
        public static void Main()
        {
            string jsonString = Console.ReadLine();

            if (ValidateJsonString(jsonString))
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid");
            }

            Console.Read();
        }

        public static bool ValidateJsonString(string jsonString)
        {
            if (jsonString[0] != '\"' || jsonString[jsonString.Length - 1] != '\"')
            {
                return false;
            }

            return true;
        }
    }
}
