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
            if (jsonString == string.Empty)
            {
                return true;
            }

            string controlChars = "\"\\/bfnrtu";
            for (int i = 1; i < jsonString.Length - 2; i++)
            {
                if (jsonString[i + 1] < 32 || jsonString[i] == '"')
                {
                    return false;
                }

                if (jsonString[i] == '\\')
                { 
                    if (jsonString[i + 1] == '\\')
                    {
                        continue;
                    }

                    if (!controlChars.Contains(jsonString[i + 1]))
                    {
                        return false;
                    }
                }

                if (jsonString[i] == 'u' && i + 5 < jsonString.Length - 1)
                {
                   if (!ValidateHexaDigits(jsonString, i))
                    {
                        return false;
                    }
                }
            }

            if (jsonString.Length < 2)
            {
                return false;
            }

            return jsonString[0] == '\"' && jsonString[jsonString.Length - 1] == '\"';
        }

        static bool ValidateHexaDigits(string hexaString, int i)
        {
            for (int k = i + 1; k <= i + 4; k++)
            {
                if (hexaString[k] >= '0' && hexaString[k] <= '9')
                {
                    continue;
                }
                else if (hexaString[k] >= 'A' && hexaString[k] <= 'F')
                {
                    continue;
                }
                else if (hexaString[k] >= 'a' && hexaString[k] <= 'f')
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }
    }
}
